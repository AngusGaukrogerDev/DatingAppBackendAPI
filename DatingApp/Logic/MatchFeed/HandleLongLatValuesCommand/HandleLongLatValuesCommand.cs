using DatingApp.Models;

namespace DatingApp.Logic.MatchFeed.HandleLongLatValuesCommand
{
    public class HandleLongLatValuesCommand : IHandleLongLatValuesCommand
    {
        private const double EarthRadiusKm = 6371.0;

        public double CalculateDistanceFromUser(StandardApplicationUser searchingUser, StandardApplicationUser userInQuestion)
        {
            double latitudeDistanceFromUserInKm = CalculateLatitudeDistanceInKm(searchingUser.CurrentLocationLatitude, userInQuestion.CurrentLocationLatitude);
            double longitudeDistanceFromUserInKm = CalculateLongitudeDistanceInKm(searchingUser.CurrentLocationLongitude, userInQuestion.CurrentLocationLongitude);

            double distanceFromUser = CalculateTotalDistance(latitudeDistanceFromUserInKm, longitudeDistanceFromUserInKm);

            return distanceFromUser;
        }

        private double CalculateLatitudeDistanceInKm(double latitudeValueOfSearchingUser, double latitudeValueOfUserInQuestion)
        {
            double latitudeRad1 = DegreesToRadians(latitudeValueOfSearchingUser);
            double latitudeRad2 = DegreesToRadians(latitudeValueOfUserInQuestion);

            double deltaLatitude = latitudeRad2 - latitudeRad1;

            double latitudeValueinKm = 2 * Math.PI * EarthRadiusKm * Math.Abs(deltaLatitude) / 360.0;

            return latitudeValueinKm;
        }

        private double CalculateLongitudeDistanceInKm(double longitudeValueOfSearchingUser, double longitudeValueOfUserInQuestion)
        {
            double longitudeRad1 = DegreesToRadians(longitudeValueOfSearchingUser);
            double longitudeRad2 = DegreesToRadians(longitudeValueOfUserInQuestion);

            double deltaLongitude = longitudeRad2 - longitudeRad1;

            double longitudeValueinKm = deltaLongitude * EarthRadiusKm;

            return longitudeValueinKm;
        }

        public double CalculateTotalDistance(double xDistance, double yDistance)
        {
            double distanceSquared = (xDistance * xDistance) + (yDistance * yDistance);
            double totalDistance = Math.Sqrt(distanceSquared);

            return totalDistance;
        }
        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
