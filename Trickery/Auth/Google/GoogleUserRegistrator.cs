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

        public async Task<UserRegistrationResult> TryRegisterUser(UserRegistrationData registrationData)
        {
            var userData = await userRepository.GetUser(registrationData.ExternalId);

            if (userData == null)
            {
                userData = await userRepository.RegisterUser(registrationData);
                await userRepository.SaveGoogleMap(userData, registrationData.ExternalId);

                return new UserRegistrationResult { NewUserRegistered = true, UserData = userData };
            }
            return new UserRegistrationResult { UserData = userData };
        }
    }
}
