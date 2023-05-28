using DatingApp.Data;
using DatingApp.Models;

namespace DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand
{
    public class GetNextUserInFeedCommand : IGetNextUserInFeedCommand
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

        private StandardApplicationUser SelectUserRandomlyFromListOfUsers(int userId)
        {
            var random = new Random();

            List<StandardApplicationUser> filteredUsers = GetFilteredUsers(userId);

            int index = random.Next(filteredUsers.Count);

            return filteredUsers[index];
        }

        private List<StandardApplicationUser> GetFilteredUsers(int userId)
        {

            List<string> usersInterests = GetUsersInterests(userId);

            List<StandardApplicationUser> filteredUsers = FindUsersMeetingSearchParameters(usersInterests);

            return filteredUsers;

        }

        private List<string> GetUsersInterests(int userId)
        {

            List<string> interests = _appDbContext.StandardApplicationUser.Where(u => u.Id == userId).Select(u => u.Interests).FirstOrDefault();

            return interests;
        }

        private List<StandardApplicationUser> FindUsersMeetingSearchParameters(List<string> searchingUsersInterests)
        {

            //TODO: Angus -  Db Logic Here.... Search database for users with matching interests
            List<StandardApplicationUser> usersWithMatchingInterests = _appDbContext.StandardApplicationUser.Where(u => searchingUsersInterests.All(interest => u.Interests.Contains(interest))).ToList();
            //List<StandardApplicationUser> usersWithMatchingInterests = _appDbContext.StandardApplicationUser.Add(u => u.Interests == searchingUsersInterests);

            return usersWithMatchingInterests;

        }

    }
}
