using System.Threading.Tasks;
using Trickery.ViewModel.Auth;

namespace Trickery.Auth
{
    public interface IUserDataProvider
    {
        Task<UserData> GetUserData(string externalUserId);
    }
}
