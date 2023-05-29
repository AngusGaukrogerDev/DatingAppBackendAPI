using DatingApp.Models;

namespace DatingApp.Logic.Users.CheckUserAgeCommand
{
    public interface ICheckUserAgeCommand
    {
        int CheckUsersAge(StandardApplicationUser user);
    }
}