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

            MongoDB.Bson.Serialization.BsonClassMap.RegisterClassMap<Model.Document.TestMessage>(map =>
            {
                map.AutoMap();
                map.AddKnownType(typeof(Model.Document.TestMessageA));
                map.AddKnownType(typeof(Model.Document.TestMessageB));
            });
        }
    }
}
