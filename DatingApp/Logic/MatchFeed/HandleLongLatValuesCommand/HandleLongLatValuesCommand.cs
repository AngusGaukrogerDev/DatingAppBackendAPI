using DatingApp.Models;

namespace DatingApp.Logic.MatchFeed.HandleLongLatValuesCommand
{
    public class HandleLongLatValuesCommand
    {
        
        public float CalculateDistanceFromUser(StandardApplicationUser searchingUser, StandardApplicationUser userInQuestion )
        {
            float distanceFromUser = 0;
            float latitudeDistanceFromUserInKm = CalculateLatitudeDistanceInKm(searchingUser.LatitudeLocation, userInQuestion.LatitudeLocation);
            float longtitudeDistanceFromUserInKm = CalculateLongtitudeDistanceInKm(searchingUser.LongtitudeLocation, userInQuestion.LongtitudeLocation);

            //TODO: trig to find distance
            return distanceFromUser;
        }

        private float CalculateLatitudeDistanceInKm(float latitudeValueOfSearchingUser, float latitudeValueOfUserInQuestion) 
        {
            float latitudeValueinKm = 0;

            //TODO: Formula to calc lat distance in km

            return latitudeValueinKm;
        }
        
        private float CalculateLongtitudeDistanceInKm(float longtitudeValueOfSearchingUser, float longtitudeValueOfUserInQuestion) 
        {
            float longtitudeValueinKm = 0;

            //TODO: Formula to calc long distance in km

            return longtitudeValueinKm;
        }

        
    }
}
