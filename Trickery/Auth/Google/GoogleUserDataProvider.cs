using System.Threading.Tasks;
using Trickery.DAL.Repository.Auth.Google;
using Trickery.ViewModel.Auth;

namespace Trickery.Auth.Google
{
    public class GoogleUserDataProvider : IUserDataProvider
    {
        private readonly IGoogleUserRepository userRepository;

        public GoogleUserDataProvider(IGoogleUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserData> GetUserData(string externalUserId)
        {
            return await userRepository.GetUser(externalUserId);
        }
    }
}
