using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Interfaces
{
    public interface ITokenService
    {

        string CreateToken(AppUser user);
    }
}
