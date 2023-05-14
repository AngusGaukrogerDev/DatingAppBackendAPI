using DatingApp.Data;
using DatingApp.Models;
using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Users.UpdateUserDetailsCommand
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly ILogger<UpdateUserCommand> _logger;
        private readonly IAppDbContext _appDbContext;

        public UpdateUserCommand(ILogger<UpdateUserCommand> logger, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public int UpdateUser(int id, string email, Gender gender, Orientation orientation, string bio)
        {
            int _statusCode = 0;

            StandardApplicationUser user = _appDbContext.StandardApplicationUser.FirstOrDefault(u => u.Id == id);

            if (user != null) 
            {
                user.Email = email;
                user.Gender = gender;
                user.Bio = bio;
                user.Orientation = orientation;

                _appDbContext.SaveChanges();

                _statusCode = StatusCodes.Status200OK;
            }
            else
            {
                _statusCode = StatusCodes.Status400BadRequest;
            }

            return _statusCode;


        }


    }
}
