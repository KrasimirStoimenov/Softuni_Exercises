namespace Git.Data
{
    public class DataConstants
    {
        public const int UserUsernameMinLength = 5;
        public const int UserUsernameMaxLength = 20;
        public const int UserPasswordMinLength = 6;
        public const int UserPasswordMaxLength = 20;
        public const string EmailRegularExpression = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        public const int RepositoryNameMinLength = 3;
        public const int RepositoryNameMaxLength = 10;
        public const string RepositoryTypePrivate = "Private";
        public const string RepositoryTypePublic = "Public";
    }
}
