using DatingApp.Logic.Users.CreateUserCommand;
using DatingApp.Logic.Users.DeleteUserCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ICreateUserCommand _createUserCommand;
        private readonly IDeleteUserCommand _deleteUserCommand;

        public UserController(ILogger<UserController> logger, ICreateUserCommand createUserCommand, IDeleteUserCommand deleteUserCommand)
        {
            _logger = logger;
            _createUserCommand = createUserCommand;
            _deleteUserCommand = deleteUserCommand;

        }

        [HttpPost("/api/UserController/CreateUser")]
        public int CreateUser(string firstName, string lastName, string email, int age, Gender gender, Orientation orientation, string bio)
        {
            int statusCode = _createUserCommand.CreateUser(firstName, lastName, email, age, gender, orientation, bio);

            return statusCode;
        }

        [HttpDelete("/api/UserController/DeleteUser")]
        public int DeleteUser(int id)
        {
            int statusCode = _deleteUserCommand.DeleteUser(id);

            return statusCode;
        }
    }
}
