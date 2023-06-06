using System.ComponentModel.DataAnnotations;

namespace DatingApp.Models
{
    public class MatchesAndConversationProgress
    {
        [Key]
        public int MatchId {  get; set; }
        public List<int> MatchedUsersIds { get; set; }
        public int ConversationLevel { get; set; }
        public bool ActiveMatch { get; set; }
        public DateTime DateOfMatch { get; set; }
        public DateTime DateOfLastInteraction { get; set; }

    }
}
