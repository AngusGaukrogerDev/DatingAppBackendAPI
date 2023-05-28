using DatingApp.Models;

namespace DatingApp.Logic.Filters.FilterUsersByLocationCommand
{
    public interface IFilterUsersByLocationCommand
    {
        StandardApplicationUser SelectUserRandomlyFromListOfNearbyUsers(int userId);
        List<StandardApplicationUser> GetListOfNearbyUsers(int userId);
    }
}