using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Models.BaseModels
{
    public class GenericUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }    
        public string LastName { get; set; }    
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Orientation Orientation { get; set; }
        public string CurrentLocationRegion { get; set; }
        public List<int> AgeRange { get; set; }
    }
}
