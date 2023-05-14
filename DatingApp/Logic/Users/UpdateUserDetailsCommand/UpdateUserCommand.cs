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
                _statusCode = TestForNullValuesAndAssign(user, email, gender, orientation, bio);
            }
            else
            {
                _statusCode = StatusCodes.Status400BadRequest;
            }

            return _statusCode;


        }

        private int TestForNullValuesAndAssign(StandardApplicationUser user, string email, Gender gender, Orientation orientation, string bio) 
        {
            int _statusCode = 0;

            if(email != null) 
            {
                user.Email = email;
            }        
            if(bio != null) 
            {
                user.Bio = bio;
            }
            
            user.Orientation = orientation;       
            user.Gender = gender;

            _appDbContext.SaveChanges();

            return _statusCode;
        }
    }
}
