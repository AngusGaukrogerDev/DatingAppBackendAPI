using DatingApp.Logic.Users.CreateUserCommand;
using DatingApp.Logic.Users.DeleteUserCommand;
using DatingApp.Logic.Users.UpdateUserDetailsCommand;
using DatingApp.Models;
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

        [HttpPost("/api/UserController/User/CreateUser")]
        public IActionResult CreateUser(StandardApplicationUser newUser)
        {
            int statusCode = _createUserCommand.CreateUser(newUser);

            return Ok(statusCode);
        }

        [HttpDelete("/api/UserController/User/DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            int statusCode = _deleteUserCommand.DeleteUser(id);

            return Ok(statusCode);
        }
        
        //Make sure frontend always sends data with all args filled in for now - Even if values are the same for some args
        //May require an update for each parameter... :/
        [HttpPut("/api/UserController/User/UpdateUser")]
        public IActionResult UpdateUser(StandardApplicationUser updatedUserDetails)
        {

            int statusCode = _updateUserCommand.UpdateUser(updatedUserDetails);

            return Ok(statusCode);
        }

        [HttpPost("/api/UserController/UserMedia/UploadProfileImageToBucket")]
        public ActionResult UploadProfileImageToBucket()
        {
            int statusCode = 0;

            return Ok(statusCode);
        }

        [HttpPost("/api/UserController/UserMedia/RemoveProfileImageFromBucket")]
        public ActionResult RemoveProfileImageFromBucket()
        {
            int statusCode = 0;

            return Ok(statusCode);
        }
    }
}
