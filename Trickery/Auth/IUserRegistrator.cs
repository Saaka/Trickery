using System.Threading.Tasks;
using Trickery.ViewModel.Auth;

namespace Trickery.Auth
{
    public interface IUserRegistrator
    {
        Task<UserRegistrationResult> TryRegisterUser(UserRegistrationData registrationData);
    }
}
