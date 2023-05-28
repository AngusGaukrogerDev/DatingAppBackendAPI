using DatingApp.Data;
using DatingApp.Models;
using static DatingApp.Constants.BaseUserConstants;

namespace DatingApp.Logic.Filters.FilterUsersByGenderCommand
{
    public class FilterUsersByGenderCommand : IFilterUsersByGenderCommand
    {
        private readonly ILogger<FilterUsersByGenderCommand> _logger;
        private readonly IAppDbContext _appDbContext;


        public FilterUsersByGenderCommand(ILogger<FilterUsersByGenderCommand> logger, IAppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public List<StandardApplicationUser> SelectUserRandomlyFromListOfUsersBasedOffCurrentUsersOrientation(int userId)
        {
            List<Gender> usersInterests = EstablishUsersInterests(userId);
            List<StandardApplicationUser> eligibleUsersBasedOffOrientation = new List<StandardApplicationUser>();

            foreach (var interest in usersInterests)
            {
                eligibleUsersBasedOffOrientation.AddRange(_appDbContext.StandardApplicationUser.Where(u => u.Gender == interest).ToList());
            }

            return eligibleUsersBasedOffOrientation;
        }

        private List<Gender> EstablishUsersInterests(int userId)
        {
            List<Gender> gender = new List<Gender>();

            StandardApplicationUser searchingUser = _appDbContext.StandardApplicationUser.Where(u => u.Id == userId).FirstOrDefault();

            switch (searchingUser.Gender)
            {
                case Gender.Male:
                    {
                        gender = MaleOrientation(searchingUser.Orientation);
                        break;
                    }
                case Gender.Female:
                    {
                        gender = FemaleOrientation(searchingUser.Orientation);
                        break;
                    }
                case Gender.Other:
                    {
                        gender = OtherOrientation(searchingUser.Orientation);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return gender;
        }

        private List<Gender> MaleOrientation(Orientation orientation)
        {
            List<Gender> preference = new List<Gender>();

            switch (orientation)
            {
                case Orientation.Straight:
                    {
                        preference.Add(Gender.Female);
                        break;
                    }
                case Orientation.Gay:
                    {
                        preference.Add(Gender.Male);
                        break;
                    }
                case Orientation.Bisexual:
                    {
                        preference.Add(Gender.Female);
                        preference.Add(Gender.Male);
                        break;
                    }
                case Orientation.Pansexual:
                    {
                        preference.Add(Gender.Female);
                        preference.Add(Gender.Male);
                        preference.Add(Gender.Other);

                        break;
                    }
                default:
                    break;
            }

            return preference;
        }

        private List<Gender> FemaleOrientation(Orientation orientation)
        {
            List<Gender> preference = new List<Gender>();

            switch (orientation)
            {
                case Orientation.Straight:
                    {
                        preference.Add(Gender.Male);
                        break;
                    }
                case Orientation.Lesbian:
                    {
                        preference.Add(Gender.Female);
                        break;
                    }
                case Orientation.Bisexual:
                    {
                        preference.Add(Gender.Female);
                        preference.Add(Gender.Male);
                        break;
                    }
                case Orientation.Pansexual:
                    {
                        preference.Add(Gender.Female);
                        preference.Add(Gender.Male);
                        preference.Add(Gender.Other);

                        break;
                    }
                default:
                    break;
            }

            return preference;
        }

        private List<Gender> OtherOrientation(Orientation orientation)
        {
            List<Gender> preference = new List<Gender>();

            switch (orientation)
            {
                case Orientation.TransLikesMen:
                    {
                        preference.Add(Gender.Male);
                        break;
                    }
                case Orientation.TransLikesWomen:
                    {
                        preference.Add(Gender.Female);
                        break;
                    }
                case Orientation.Bisexual:
                    {
                        preference.Add(Gender.Female);
                        preference.Add(Gender.Male);
                        break;
                    }
                case Orientation.Pansexual:
                    {
                        preference.Add(Gender.Female);
                        preference.Add(Gender.Male);
                        preference.Add(Gender.Other);

                        break;
                    }
                case Orientation.TransLikesTrans:
                    {
                        preference.Add(Gender.Other);

                        break;
                    }
                default:
                    break;
            }

            return preference;
        }
    }
}
