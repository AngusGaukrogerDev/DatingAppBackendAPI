using DatingApp.Models;

namespace DatingApp.Logic.Users.CheckUserAgeCommand
{
    public class CheckUserAgeCommand : ICheckUserAgeCommand
    {
        public int CheckUsersAge(StandardApplicationUser user)
        {
            DateTime currentDate = DateTime.Now;

            int age = currentDate.Year - user.DateOfBirth.Year;

            return age;
        }
    }
}
