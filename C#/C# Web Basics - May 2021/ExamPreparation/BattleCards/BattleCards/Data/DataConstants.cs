namespace BattleCards.Data
{
    public class DataConstants
    {
        public const int UsernameMaxLength = 20;
        public const int UsernameMinLength = 5;
        public const int PasswordMaxLength = 20;
        public const int PasswordMinLength = 6;
        public const string EmailRegularExpression = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        public const int CardNameMaxLength = 15;
        public const int CardNameMinLength = 5;
        public const int CardDescriptionMaxLength = 200; 
    }
}
