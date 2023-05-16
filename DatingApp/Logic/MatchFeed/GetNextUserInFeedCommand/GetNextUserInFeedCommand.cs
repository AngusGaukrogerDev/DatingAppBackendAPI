using DatingApp.Data;
using DatingApp.Logic.Users.CreateUserCommand;
using DatingApp.Models;
using System.Collections.Generic;

namespace DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand
{
    public class GetNextUserInFeedCommand
    {
        private readonly ILogger<GetNextUserInFeedCommand> _logger;
        private readonly IAppDbContext _appDbContext;

        public GetNextUserInFeedCommand(ILogger<GetNextUserInFeedCommand> logger, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public StandardApplicationUser GetNextUserInFeed(int userId)
        {
            StandardApplicationUser nextFilteredUser;

            nextFilteredUser = SelectUserRandomlyFromListOfUsers(userId);

            return nextFilteredUser;
        }

        public StandardApplicationUser SelectUserRandomlyFromListOfUsers(int userId)
        {
            var random = new Random();

            List<StandardApplicationUser> filteredUsers = GetFilteredUsers(userId);

            int index = random.Next(filteredUsers.Count);

            return filteredUsers[index];
        }

        public List<StandardApplicationUser> GetFilteredUsers(int userId)
        {

            List<string> usersInterests = GetUsersInterests(userId);

            List<StandardApplicationUser> filteredUsers = FindUsersMeetingSearchParameters(usersInterests);

            return filteredUsers;

        }

        public List<string> GetUsersInterests(int userId)
        {
            List<string> interests = new List<string>();

            //TODO: Angus - Db Logic here..... Query database and use linq to filter by user ID. Grab interests data from this

            return interests;
        }

        public List<StandardApplicationUser> FindUsersMeetingSearchParameters(List<string> searchingUsersInterests)
        {
            List<StandardApplicationUser> usersWithMatchingInterests = new List<StandardApplicationUser>();

            //TODO: Angus -  Db Logic Here.... Search database for users with matching interests

            return usersWithMatchingInterests;

        }

    }
}
