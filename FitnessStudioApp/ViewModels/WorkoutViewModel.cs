
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FitnessStudioApp.Models.Workout;
using FitnessStudioApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FitnessStudioApp.ViewModels
{
    public partial class WorkoutViewModel : ObservableObject
    {
        public LocalizationResourceManager LocalizationResourceManager => LocalizationResourceManager.Instance;
        private ObservableCollection<ExerciseViewModel> exercises;
        private ObservableCollection<string> availableExercises;
        private string selectedExercise;
        private readonly IApiService _apiService;
        public bool IsBusy = false;
        private string _token;
        public string Token
        {
            get => _token;
            set { _token = value; OnPropertyChanged(); }
        }

        [ObservableProperty]
        string workoutName;

        public WorkoutViewModel(IApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            Exercises = new ObservableCollection<ExerciseViewModel>();
            AvailableExercises = new ObservableCollection<string> {
              "Military Press",
              "Cable Lateral Raise",
              "Dumbbell Shoulder Press",
              "Barbell Bench Press",
              "Incline Smith Machine Bench",
              "Barbell Back Squat",
              "Leg Press",
              "Barbell Row",
              "Pull Up",
              "Face Pull",
              "Dips",
              "Dumbbell Biceps Curls"
            };
            AddExerciseCommand = new RelayCommand(AddExercise);
            AddSetCommand = new RelayCommand<ExerciseViewModel>(AddSet);
            PostWorkoutCommand = new Command(async () => await PostWorkout(), () => !IsBusy);
            InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await LoadToken();
        }
        private async Task LoadToken()
        {
            Token = await SecureStorage.GetAsync("jwt_token");
        }

        public ICommand PostWorkoutCommand { get; }

        async Task PostWorkout()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                var workoutRequest = new WorkoutRequest { name = workoutName,exercises =exercises };
                var response = await _apiService.PostWorkout($"Bearer {Token}",workoutRequest);
                await Application.Current.MainPage.DisplayAlert("Success", "Congratulations! Your workout has been posted successfully", "OK");
                ResetScreen();

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid credentials", ex.Message.ToString(), "OK");

            }
            finally
            {
                IsBusy = false;
            }
        }
        public ObservableCollection<ExerciseViewModel> Exercises
        {
            get { return exercises; }
            set { SetProperty(ref exercises, value); }
        }

        public ObservableCollection<string> AvailableExercises
        {
            get { return availableExercises; }
            set { SetProperty(ref availableExercises, value); }
        }

        public string SelectedExercise
        {
            get { return selectedExercise; }
            set { SetProperty(ref selectedExercise, value); }
        }

        public IRelayCommand AddExerciseCommand { get; }
        public IRelayCommand<ExerciseViewModel> AddSetCommand { get; }

        private void AddExercise()
        {
            if (!string.IsNullOrEmpty(SelectedExercise))
            {
                Exercises.Add(new ExerciseViewModel { ExerciseId = GetExerciseIdByName(SelectedExercise), Name = SelectedExercise });
                SelectedExercise = null;
            }
        }

        private void AddSet(ExerciseViewModel exercise)
        {
            if (exercise != null)
            {
                exercise.Sets.Add(new SetViewModel());
            }
        }

        private void ResetScreen()
        {
            WorkoutName = string.Empty;
            Exercises.Clear();
        }
        private int GetExerciseIdByName(string exerciseName)
        {
            switch (exerciseName)
            {
                case "Military Press":
                    return 1;
                case "Cable Lateral Raise":
                    return 2;
                case "Dumbbell Shoulder Press":
                    return 3;
                case "Barbell Bench Press":
                    return 4;
                case "Incline Smith Machine Bench":
                    return 5;
                case "Barbell Back Squat":
                    return 6;
                case "Leg Press":
                    return 7;
                case "Barbell Row":
                    return 8;
                case "Pull Up":
                    return 9;
                case "Face Pull":
                    return 10;
                case "Dips":
                    return 11;
                case "Dumbbell Biceps Curls":
                    return 12;
                default:
                    return 1; // Default to 1 if exercise name not found
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ExerciseViewModel : INotifyPropertyChanged
    {
        private int exerciseId;
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged(); }
        }
        public int ExerciseId
        {
            get { return exerciseId; }
            set { exerciseId = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<SetViewModel> sets;
        public ObservableCollection<SetViewModel> Sets
        {
            get { return sets; }
            set { sets = value; NotifyPropertyChanged(); }
        }

        public ExerciseViewModel()
        {
            Sets = new ObservableCollection<SetViewModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SetViewModel : INotifyPropertyChanged
    {
        private int reps;
        public int Reps
        {
            get { return reps; }
            set { reps = value; NotifyPropertyChanged(); }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set { weight = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
