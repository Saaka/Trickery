using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Trickery.DAL.Repository.Auth.Google;
using Trickery.ViewModel.Auth;

namespace Trickery.Auth.Google
{
    public class GoogleUserDataProvider : IUserDataProvider
    {
        private readonly IGoogleUserRepository userRepository;
        private readonly IMemoryCache memoryCache;

        public GoogleUserDataProvider(
            IGoogleUserRepository userRepository,
            IMemoryCache memoryCache)
        {
            this.userRepository = userRepository;
            this.memoryCache = memoryCache;
        }

        public async Task<UserData> GetUserData(string externalUserId)
        {
            var userData = await memoryCache.GetOrCreateAsync(externalUserId, async (e) =>
            {
                e.SlidingExpiration = TimeSpan.FromHours(3);
                e.AbsoluteExpiration = DateTime.Now.AddDays(1);

                var user = await userRepository.GetUser(externalUserId);

                return user;
            });

            return userData;
        }
    }
}
