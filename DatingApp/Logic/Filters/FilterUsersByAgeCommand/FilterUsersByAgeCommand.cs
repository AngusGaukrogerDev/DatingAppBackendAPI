using DatingApp.Data;
using DatingApp.Logic.Users.CheckUserAgeCommand;
using DatingApp.Models;
using System.Collections.Generic;

namespace DatingApp.Logic.Filters.FilterUsersByAgeCommand
{
    public class FilterUsersByAgeCommand : IFilterUsersByAgeCommand
    {
        private readonly ILogger<FilterUsersByAgeCommand> _logger;
        private readonly IAppDbContext _appDbContext;

        private readonly ICheckUserAgeCommand _checkUserAgeCommand;
        public FilterUsersByAgeCommand(ILogger<FilterUsersByAgeCommand> logger, IAppDbContext appDbContext, ICheckUserAgeCommand checkUserAgeCommand)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _checkUserAgeCommand = checkUserAgeCommand;
        }

        public List<StandardApplicationUser> GetUsersBasedOffAge(int userId, List<StandardApplicationUser> usersToSearch)
        {

            StandardApplicationUser searchingUser = _appDbContext.StandardApplicationUser.Where(u => u.Id == userId).FirstOrDefault();

            List<StandardApplicationUser> usersInTargetAgeRange = SearchListOfUsersForUsersWithinAgeRange(searchingUser, usersToSearch);

            return usersInTargetAgeRange;
        }

        private List<StandardApplicationUser> SearchListOfUsersForUsersWithinAgeRange(StandardApplicationUser searchingUser, List<StandardApplicationUser> usersToSearch)
        {
            List<StandardApplicationUser> usersOfAppropriateAge = new List<StandardApplicationUser>();

            int ageToCheck = searchingUser.AgeRange[0];

            while (ageToCheck != searchingUser.AgeRange[1])
            {
                usersOfAppropriateAge.AddRange(usersToSearch.Where(u => _checkUserAgeCommand.CheckUsersAge(u) == ageToCheck).ToList());

                ageToCheck++;
            }

            return usersOfAppropriateAge;
        }

    }
}
