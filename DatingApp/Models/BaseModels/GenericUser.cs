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
        public double CurrentLocationLatitude { get; set; }
        public double CurrentLocationLongitude { get; set; }
        public int DesiredRangeinKm { get; set; }   
        public List<int> AgeRange { get; set; }
    }
}
