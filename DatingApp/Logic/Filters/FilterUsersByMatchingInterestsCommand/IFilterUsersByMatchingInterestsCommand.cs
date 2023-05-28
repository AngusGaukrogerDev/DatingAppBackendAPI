using DatingApp.Models;

namespace DatingApp.Logic.Filters.FilterUsersByMatchingInterestsCommand
{
    public interface IFilterUsersByMatchingInterestsCommand
    {
        StandardApplicationUser SelectUserRandomlyFromListOfUsers(int userId);
        List<StandardApplicationUser> GetFilteredUsersByInterest(int userId);
    }
}