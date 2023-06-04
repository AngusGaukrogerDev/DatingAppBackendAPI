using DatingApp.Data;
using DatingApp.Models;

namespace DatingApp.Logic.Users.DeleteUserCommand
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly ILogger<DeleteUserCommand> _logger;
        private readonly IAppDbContext _appDbContext;

        public DeleteUserCommand(ILogger<DeleteUserCommand> logger, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public int DeleteUser(int id)
        {
            int _statusCode = 0;
            
            StandardApplicationUser user = _appDbContext.StandardApplicationUser.FirstOrDefault(u => u.Id == id);
            UserLikesAndMatches userLikesAndMatches = _appDbContext.UserLikesAndMatches.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                _appDbContext.StandardApplicationUser.Remove(user);
                _appDbContext.UserLikesAndMatches.Remove(userLikesAndMatches);

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
