using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Models
{
    public interface IStandardApplicationUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        DateTime DateOfBirth { get; set; }
        Gender Gender { get; set; }
        Orientation Orientation { get; set; }
        string CurrentLocationRegion { get; set; }
        string Bio { get; set; }
        List<string> Interests { get; set; }
        List<string> Photos { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public string? CourseName { get; set; }
        public string? UniversityName { get; set; }
        public string? Hometown { get; set; }
        public string? Nationality { get; set; }
    }
}