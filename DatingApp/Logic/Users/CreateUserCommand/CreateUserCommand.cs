using DatingApp.Data;
using DatingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Users.CreateUserCommand
{
    public class CreateUserCommand : ICreateUserCommand
    {
       
        private readonly ILogger<CreateUserCommand> _logger;
        private readonly IAppDbContext _appDbContext;

        public CreateUserCommand(ILogger<CreateUserCommand> logger, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public int CreateUser(StandardApplicationUser createdUser)
        {
            //TODO: Angus - Change with MinioIntegration
            List<string> interests = new List<string>{ "first", "second" };
            List<string> photos = new List<string>{ "first", "second" };

            //Temp
            createdUser.Interests = interests;
            createdUser.Photos = photos;

            _appDbContext.StandardApplicationUser.Add(createdUser);
            _appDbContext.UserLikesAndMatches.Add(new UserLikesAndMatches
            {
                Id = createdUser.Id,
            });
            _appDbContext.SaveChanges();

            return StatusCodes.Status200OK;
        }

        
    }
}
