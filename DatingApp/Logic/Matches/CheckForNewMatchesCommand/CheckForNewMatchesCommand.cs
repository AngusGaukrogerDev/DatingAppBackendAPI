using DatingApp.Data;
using DatingApp.Models;

namespace DatingApp.Logic.Matches.CheckForNewMatchesCommand
{
    public class CheckForNewMatchesCommand : ICheckForNewMatchesCommand
    {
        private readonly IAppDbContext _appDbContext;
        public CheckForNewMatchesCommand(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<MatchesAndConversationProgress> CheckForNewMatches(StandardApplicationUser searchingUser)
        {
            List<MatchesAndConversationProgress> newMatches = new();

            UserLikesAndMatches usersLikeData = _appDbContext.UserLikesAndMatches.Where(u => u.Id == searchingUser.Id).FirstOrDefault();

            //check users sent and received likes to find user ids that appear in both columns
            List<int> idsThatAppearInBothSentAndReceivedLikesColumn = FilterSentAndReceivedLikesForMatches(usersLikeData);

            // Check that matches do not already exist in matching table (if they do, just remove the id from likes column and add match id to matches column
            //Create new matches in matching table storing both users id for every new match
            // Remove all found new matches from sent/received likes
            // 


            return newMatches;
        }

        private List<int> FilterSentAndReceivedLikesForMatches(UserLikesAndMatches usersLikes)
        {
            List<int> newMatches = new();

            foreach (var sentLike in usersLikes.SentLikes)
            {
                foreach (var receivedLike in usersLikes.ReceivedLikes)
                {
                    if (sentLike == receivedLike && !DoesMatchAlreadyExistInMatchingTable(usersLikes.Id, sentLike))
                    {
                        newMatches.Add(sentLike);

                        //make sure this happens in db!
                        usersLikes.SentLikes.Remove(sentLike);
                        usersLikes.ReceivedLikes.Remove(receivedLike);

                        List<int> matchedUsersIds = new List<int>() { usersLikes.Id, sentLike };

                        _appDbContext.MatchesAndConversationProgress.Add(new MatchesAndConversationProgress
                        {
                            DateOfLastInteraction = DateTime.Now,
                            DateOfMatch = DateTime.Now,
                            ActiveMatch = true,
                            MatchedUsersIds = matchedUsersIds,
                            ConversationLevel = 0,
                        });

                        _appDbContext.SaveChanges();
                    }
                    else if (sentLike == receivedLike && DoesMatchAlreadyExistInMatchingTable(usersLikes.Id, sentLike))
                    {
                        //make sure this happens in db!

                        usersLikes.SentLikes.Remove(sentLike);
                        usersLikes.ReceivedLikes.Remove(receivedLike);
                        _appDbContext.SaveChanges();

                        //Remove likes - search for match Id of existing match and add to UserLikesAndMatches for this user
                    }
                }
            }

            //Create new entries in match table for all new matches


            return newMatches;
        }

        private bool DoesMatchAlreadyExistInMatchingTable(int userId, int matchId)
        {
            bool matchExistsAlready = false;

            MatchesAndConversationProgress matchWithCorrespondingIds = new();

            List<int> possibleIdCombos = new List<int>() { userId, matchId };
            List<int> possibleIdCombos1 = new List<int>() { matchId, userId };

            List<List<int>> possibleCombos = new List<List<int>>() { possibleIdCombos, possibleIdCombos };

            foreach (var combo in possibleCombos)
            {
                matchWithCorrespondingIds = _appDbContext.MatchesAndConversationProgress.Where(i => i.MatchedUsersIds == combo).FirstOrDefault();

                if (matchWithCorrespondingIds != null)
                {
                    matchExistsAlready = true;
                }
            }

            return matchExistsAlready;
        }

        private
    }
}
