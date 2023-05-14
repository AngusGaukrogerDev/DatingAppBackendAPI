using DatingApp.Models.BaseModels;

namespace DatingApp.Models
{
    public class StandardApplicationUser : GenericUser, IStandardApplicationUser
    {
        public List<string> Interests { get; set; }
        public List<string> Photos { get; set; }
        public string Bio { get; set; }
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public string? CourseName { get; set; }
        public string? UniversityName { get; set; }
        public string? Hometown { get; set; }
        public string? Nationality { get; set;}
    }
}
