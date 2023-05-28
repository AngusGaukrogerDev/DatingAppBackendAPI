using DatingApp.Models;

namespace DatingApp.Logic.Filters.FilterUsersByGenderCommand
{
    public interface IFilterUsersByGenderCommand
    {
        List<StandardApplicationUser> SelectUserRandomlyFromListOfUsersBasedOffCurrentUsersOrientation(int userId);
    }
}