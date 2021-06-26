namespace SharedTrip.Data
{
    public class DataConstants
    {
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const string EmailRegexValidator = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        public const int TripSeatsMinValue = 2;
        public const int TripSeatsMaxValue = 6;
        public const int TripDescriptionMaxLength = 80;

    }
}