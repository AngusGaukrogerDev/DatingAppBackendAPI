using DatingApp.Models;

namespace DatingApp.Logic.Filters.FilterUsersByAgeCommand
{
    public interface IFilterUsersByAgeCommand
    {
        List<StandardApplicationUser> GetUsersBasedOffAge(int userId, List<StandardApplicationUser> usersToSearch);
    }
}