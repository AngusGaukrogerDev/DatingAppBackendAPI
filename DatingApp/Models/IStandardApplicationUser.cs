using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Models
{
    public interface IStandardApplicationUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        int Age { get; set; }
        Gender Gender { get; set; }
        Orientation Orientation { get; set; }
        string Bio { get; set; }
        List<string> Interests { get; set; }
        List<string> Photos { get; set; }
    }
}