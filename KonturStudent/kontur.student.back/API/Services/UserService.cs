using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models.UserDto;
using API.Services.Interfaces;
using IdentityModel.Client;
using KSRepositories.DbModels;
using KSRepositories.Repositories;

namespace API.Services
{
    public class UserService: IUserService
    {
        private readonly HttpClient httpClient;
        private readonly AbstractRepository<User> userRepository;

        public UserService(HttpClient httpClient, AbstractRepository<User> userRepository)
        {
            this.httpClient = httpClient;
            this.userRepository = userRepository;
        }
        
        public async Task<User> GetUserFromTokenAsync(string accessToken)
        {
            var claims = (await httpClient.GetUserInfoAsync(
                new UserInfoRequest
                {
                    Address = "https://identity.testkontur.ru/connect/userinfo",
                    Token = accessToken

                })).Claims.ToDictionary(claim => claim.Type, claim => claim.Value);

            var user = new User
            {
                Id = claims["sub"],
                Name = claims["given_name"],
                Surname = claims["family_name"],
                Email = claims["email"],
                Role = Role.User
            };

            return user;
        }

        public  Task<User> GetUserByIdAsync(string id) =>  userRepository.FindByIdAsync(id);

        public Task<User> CreateUserAsync(User user) =>  userRepository.AddAsync(user);

        public Task RemoveUserAsync(User user) =>  userRepository.RemoveAsync(user);

        public Task<User> UpdateUserAsync(User user) =>  userRepository.UpdateAsync(user);
    }
}