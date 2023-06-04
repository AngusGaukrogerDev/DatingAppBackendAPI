using DatingApp.Constants;
using DatingApp.Models;
using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Users.UpdateUserDetailsCommand
{
    public interface IUpdateUserCommand
    {
        int UpdateUser(StandardApplicationUser updatedUser);
    }
}