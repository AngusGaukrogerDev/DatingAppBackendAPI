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

        public int CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Gender gender, Orientation orientation, string bio)
        {
            //Change with MinioIntegration
            List<string> interests = new List<string>{ "first", "second" };
            List<string> photos = new List<string>{ "first", "second" };


            int _idValue = _appDbContext.StandardApplicationUser.Count();

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
                    Id = _idValue,
                    Interests = interests,
                    Photos = photos,

                }
            ); 

            _appDbContext.SaveChanges();

            return StatusCodes.Status200OK;
        }

        
    }
}
