using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Users.CreateUserCommand
{
    public interface ICreateUserCommand
    {
        int CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Gender gender, Orientation orientation, string bio);
    }
}