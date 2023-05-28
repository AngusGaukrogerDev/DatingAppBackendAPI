using DatingApp.Data;
using DatingApp.Models;
using Microsoft.EntityFrameworkCore;
using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Users.CreateUserCommand
{
    public class CreateUserCommand : ICreateUserCommand
    {
       
        private readonly ILogger<CreateUserCommand> _logger;
        private readonly IAppDbContext _appDbContext;

        public CreateUserCommand(ILogger<CreateUserCommand> logger, IStandardApplicationUser standardApplicationUser, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;

        }

        public int CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Gender gender, Orientation orientation, string bio, string location)
        {
            //TODO: Angus - Change with MinioIntegration
            List<string> interests = new List<string>{ "first", "second" };
            List<string> photos = new List<string>{ "first", "second" };
            
            _appDbContext.StandardApplicationUser.Add(
                new StandardApplicationUser
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    DateOfBirth = dateOfBirth,
                    Gender = gender,
                    Orientation = orientation,
                    Bio = bio,
                    Interests = interests,
                    Photos = photos,
                    CurrentLocationRegion = location, //TODO: Angus - Update to be set based off users current region
                }
            ); 
            
            _appDbContext.SaveChanges();

            return StatusCodes.Status200OK;
        }

        
    }
}
