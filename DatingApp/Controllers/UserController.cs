using DatingApp.Logic.Users.CreateUserCommand;
using DatingApp.Logic.Users.DeleteUserCommand;
using DatingApp.Logic.Users.UpdateUserDetailsCommand;
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
        private readonly IUpdateUserCommand _updateUserCommand;

        public UserController(ILogger<UserController> logger, ICreateUserCommand createUserCommand, IDeleteUserCommand deleteUserCommand, 
            IUpdateUserCommand updateUserCommand)
        {
            _logger = logger;

            _createUserCommand = createUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _updateUserCommand = updateUserCommand;
        }

        [HttpPost("/api/UserController/CreateUser")]
        public int CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Gender gender, Orientation orientation, string bio)
        {
            int statusCode = _createUserCommand.CreateUser(firstName, lastName, email, dateOfBirth, gender, orientation, bio);

            return statusCode;
        }

        [HttpDelete("/api/UserController/DeleteUser")]
        public int DeleteUser(int id)
        {
            int statusCode = _deleteUserCommand.DeleteUser(id);

            return statusCode;
        }
        
        [HttpPut("/api/UserController/UpdateUser")]
        public int UpdateUser(int id,  string email, Gender gender, Orientation orientation, string bio)
        {
            int statusCode = _updateUserCommand.UpdateUser(id, email, gender, orientation, bio);

            return statusCode;
        }
    }
}
