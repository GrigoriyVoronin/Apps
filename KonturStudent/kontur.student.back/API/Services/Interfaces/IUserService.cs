using System.Threading.Tasks;
using KSRepositories.DbModels;

namespace API.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserFromTokenAsync(string accessToken);

        Task<User> GetUserByIdAsync(string id);

        Task<User>  CreateUserAsync(User user) ;

        Task RemoveUserAsync(User user);

        Task<User> UpdateUserAsync(User user);
    }
}