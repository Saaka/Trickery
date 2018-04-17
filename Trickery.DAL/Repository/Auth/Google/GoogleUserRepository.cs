using System.Threading.Tasks;
using Trickery.DAL.Store;
using Trickery.ViewModel.Auth;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Trickery.Model.Entity;

namespace Trickery.DAL.Repository.Auth.Google
{
    public interface IGoogleUserRepository
    {
        Task<UserData> GetUser(string googleUserId);
        Task<UserData> RegisterUser(UserRegistrationData registrationData);
        Task SaveGoogleMap(UserData userData, string googleId);
    }

    public class GoogleUserRepository : IGoogleUserRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GoogleUserRepository(AppDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
            var user = mapper.Map<User>(registrationData);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return mapper.Map<UserData>(user);
        }

        public async Task SaveGoogleMap(UserData userData, string googleId)
        {
            var googleUserMap = new GoogleUserMap
            {
                UserId = userData.Id,
                GoogleId = googleId
            };

            await context.GoogleUserMaps.AddAsync(googleUserMap);
            await context.SaveChangesAsync();
        }
    }
}
