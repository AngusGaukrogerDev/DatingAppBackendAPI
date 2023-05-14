using DatingApp.Models.BaseModels;

namespace DatingApp.Models
{
    public class StandardApplicationUser : GenericUser, IStandardApplicationUser
    {
        public List<string> Interests { get; set; }
        public List<string> Photos { get; set; }
        public string Bio { get; set; }

    }
}
