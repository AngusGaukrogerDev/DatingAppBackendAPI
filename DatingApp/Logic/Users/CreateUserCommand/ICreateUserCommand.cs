using DatingApp.Models;
using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Users.CreateUserCommand
{
    public interface ICreateUserCommand
    {
        int CreateUser(StandardApplicationUser createdUser);
    }
}