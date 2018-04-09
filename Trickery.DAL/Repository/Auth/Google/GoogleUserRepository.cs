using System.Threading.Tasks;
using Trickery.DAL.Store;
using Trickery.ViewModel.Auth;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Trickery.DAL.Repository.Auth.Google
{
    public interface IGoogleUserRepository
    {
        Task<UserData> GetUser(string googleUserId);
        Task<UserData> RegisterUser(UserRegistrationData registrationData);
    }

    public class GoogleUserRepository : IGoogleUserRepository
    {
        private readonly AppDbContext context;

        public GoogleUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<UserData> GetUser(string googleUserId)
        {
            var query = from user in context.Users
                        join google in context.GoogleUserMaps on user.Id equals google.UserId
                        where google.GoogleId == googleUserId
                        select new UserData
                        {
                            Id = user.Id,
                            Email = user.Email, 
                            Name = user.Name, 
                            Picture = user.PictureUrl
                        };

            return await query.FirstOrDefaultAsync();

        }

        public async Task<UserData> RegisterUser(UserRegistrationData registrationData)
        {
            return new UserData
            {
                Id = 0,
                Email = registrationData.Email,
                Name = registrationData.Name,
                Picture = registrationData.Picture
            };
        }
    }
}
