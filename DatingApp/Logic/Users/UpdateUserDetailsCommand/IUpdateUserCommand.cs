using DatingApp.Constants;
using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Users.UpdateUserDetailsCommand
{
    public interface IUpdateUserCommand
    {
        int UpdateUser(int id, string email, Gender gender, Orientation orientation, string bio);
    }
}