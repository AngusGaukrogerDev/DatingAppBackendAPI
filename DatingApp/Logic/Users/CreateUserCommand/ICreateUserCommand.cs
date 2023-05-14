using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Users.CreateUserCommand
{
    public interface ICreateUserCommand
    {
        int CreateUser(string firstName, string lastName, string email, int age, Gender gender, Orientation orientation, string bio);
    }
}