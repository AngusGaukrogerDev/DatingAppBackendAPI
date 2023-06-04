using DatingApp.Models.BaseModels;

namespace DatingApp.Models
{
    public class UserLikesAndMatches 
    {
        public int Id { get; set; }
        public List<string> SentLikes { get; set; }
        public List<string> ReceivedLikes { get; set; }
        public List<string> Matches { get; set; }

    }
}
