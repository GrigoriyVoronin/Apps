using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Access;
using API.Models;
using API.Models.UserDto;
using API.Services.Interfaces;
using AutoMapper;
using KSRepositories.DbModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User = KSRepositories.DbModels.User;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/users/")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        /// <summary>
        ///     UserController constructor
        /// </summary>
        /// <param name="userRepository">AbstractRepository<User></param>
        /// <param name="mapper">IMapper</param>
        public UserController(IUserService userService, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        ///     Returns myself
        /// </summary>
        /// <returns>User</returns>
        /// <response code="200">Returns user</response>
        /// <response code="403">No authorization token</response>
        /// <response code="404">If no user in db</response>
        // GET: /users/me
        [HttpGet("me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUser() =>
            HttpContext.User.Claims
                    .First(claim => claim.Type == "sub").Value switch
            {
                var sub => await userService.GetUserByIdAsync(sub) switch
                {
                    null => NotFound(),
                    var user => Ok(user)
                }
            };

        /// <summary>
        ///     Returns user by id
        /// </summary>
        /// <returns>Found user</returns>
        /// <response code="200">Returns user</response>
        /// <response code="404">If no user in db</response>
        // GET: /users/{id}
        [HttpGet("{userId}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUser(string userId)
            => await userService.GetUserByIdAsync(userId) switch
            {
                null => NotFound(),
                var user => Ok(user)
            };


        /// <summary>
        ///     Create user
        /// </summary>
        /// <returns>Created project</returns>
        /// <response code="200">Returns created user</response>
        /// <response code="400">The user's already exists</response>
        /// <response code="403">No authorization token</response>
        // POST: /users/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> CreateUser()
        {
            var id = HttpContext.User.Claims.First(claim => claim.Type == "sub").Value;
            var userFromRepo = await userService.GetUserByIdAsync(id);

            if (userFromRepo != null)
                return BadRequest();

            var token = await HttpContext.GetTokenAsync("access_token");
            var user = await userService.GetUserFromTokenAsync(token);

            await userService.CreateUserAsync(user);

            return CreatedAtRoute("GetUser", new { userId = user.Id },
                user);
        }

        /// <summary>
        ///     Update user in db
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT/users/
        ///     {
        ///        "name": "ivan",
        ///        "surname": "ivanov",
        ///        "email": "ivanov@gmail.com"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        /// <response code="204">Update successful</response>
        /// <response code="403">No authorization token</response>
        /// <response code="404">User's not found in db</response>
        // PUT: /users/
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest updateUser)
        {
            var id = HttpContext.User.Claims
                .First(claim => claim.Type == "sub").Value;

            var userFromRepo = await userService.GetUserByIdAsync(id);

            if (userFromRepo is null)
                return BadRequest();

            mapper.Map(updateUser, userFromRepo);
            await userService.UpdateUserAsync(userFromRepo);

            return NoContent();
        }

        /// <summary>
        ///     Delete user from db
        /// </summary>
        /// <returns></returns>
        /// <response code="204">Removal successful</response>
        /// <response code="403">No authorization token</response>
        /// <response code="404">User's not found in db</response>
        // DELETE: /users/
        [HttpDelete]
        [RoleFilter(Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser()
        {
            var id = HttpContext.User.Claims
                .First(claim => claim.Type == "sub").Value;

            var userFromRepo = await userService.GetUserByIdAsync(id);

            if (userFromRepo is null)
                return BadRequest();

            await userService.RemoveUserAsync(userFromRepo);

            return NoContent();
        }

        [HttpPost("grant")]
        public async Task<ActionResult> GrantRole(GrantRoleRequest grantRoleRequest)
        {
            var user = await userService.GetUserByIdAsync(grantRoleRequest.Id);

            if (user is null)
                return NotFound();

            user.Role = grantRoleRequest.Role;
            await userService.UpdateUserAsync(user);
            return Ok(user);
        }
    }
}