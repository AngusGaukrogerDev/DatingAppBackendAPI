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

        [HttpPost("/api/UserController/User/CreateUser")]
        public ActionResult CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Gender gender, Orientation orientation, string bio, 
            string location, List<int> ageRange)
        {
            int statusCode = _createUserCommand.CreateUser(firstName, lastName, email, dateOfBirth, gender, orientation, bio, location, ageRange);

            return Ok(statusCode);
        }

        [HttpDelete("/api/UserController/User/DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            int statusCode = _deleteUserCommand.DeleteUser(id);

            return Ok(statusCode);
        }
        
        //Make sure frontend always sends data with all args filled in for now - Even if values are the same for some args
        //May require an update for each parameter... :/
        [HttpPut("/api/UserController/User/UpdateUser")]
        public ActionResult UpdateUser(int id,  string email, Gender gender, Orientation orientation, string bio)
        {

            int statusCode = _updateUserCommand.UpdateUser(id, email, gender, orientation, bio);

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
