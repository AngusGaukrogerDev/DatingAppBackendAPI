using DatingApp.Models.BaseModels;

namespace DatingApp.Models
{
    public class UserLikesAndMatches 
    {
        public int Id { get; set; }
        public List<int> SentLikes { get; set; }
        public List<int> ReceivedLikes { get; set; }
        public List<int> Matches { get; set; } //ListOfMatchIds -- TODO: Remigrate

    }
}
