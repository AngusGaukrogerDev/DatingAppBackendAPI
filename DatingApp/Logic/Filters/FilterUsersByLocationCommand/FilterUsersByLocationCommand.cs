using DatingApp.Data;
using DatingApp.Logic.MatchFeed.GetNextUserInFeedCommand;
using DatingApp.Models;

namespace DatingApp.Logic.Filters.FilterUsersByLocationCommand
{
    public class FilterUsersByLocationCommand : IFilterUsersByLocationCommand
    {
        private readonly ILogger<FilterUsersByLocationCommand> _logger;
        private readonly IAppDbContext _appDbContext;

        public FilterUsersByLocationCommand(ILogger<FilterUsersByLocationCommand> logger, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public StandardApplicationUser SelectUserRandomlyFromListOfNearbyUsers(int userId)
        {
            var random = new Random();

            List<StandardApplicationUser> nearbyUsers = GetListOfNearbyUsers(userId);

            int index = random.Next(nearbyUsers.Count);

            return nearbyUsers[index];

        }

        public List<StandardApplicationUser> GetListOfNearbyUsers(int userId)
        {
            StandardApplicationUser currentUser = _appDbContext.StandardApplicationUser.Where(u => u.Id == userId).FirstOrDefault();

            List<StandardApplicationUser> nearbyUsers = _appDbContext.StandardApplicationUser.Where(u => u.CurrentLocationRegion == currentUser.CurrentLocationRegion).ToList();

            return nearbyUsers;
        }
    }
}
