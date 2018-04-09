using System.Threading.Tasks;
using Trickery.DAL.Repository.Auth.Google;
using Trickery.ViewModel.Auth;

namespace Trickery.Auth.Google
{
    public class GoogleUserRegistrator : IUserRegistrator
    {
        private readonly IGoogleUserRepository userRepository;

        public GoogleUserRegistrator(IGoogleUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserData> TryRegisterUser(UserRegistrationData registrationData)
        {
            var userData = await userRepository.GetUser(registrationData.ExternalId);

            if (userData == null)
                userData = await userRepository.RegisterUser(registrationData);

            return userData;
        }
    }
}
