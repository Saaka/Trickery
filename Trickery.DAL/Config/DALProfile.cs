using AutoMapper;
using Trickery.Model.Entity;
using Trickery.ViewModel.Auth;

namespace Trickery.DAL.Config
{
    public class DALProfile: Profile
    {
        public DALProfile()
        {
            CreateMap<User, UserData>()
                .ForMember(x => x.Picture, s => s.ResolveUsing(x => x.PictureUrl));

            CreateMap<UserRegistrationData, User>()
                .ForMember(x => x.PictureUrl, s => s.ResolveUsing(x => x.Picture));
        }
    }
}
