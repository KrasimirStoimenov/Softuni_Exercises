﻿namespace CarShop.Data
{
    public static class DataConstants
    {
        public const int DefaultMaxLength = 20;

        public const int UserUsernameMinLength = 4;
        public const int UserPasswordMinLength = 5;
        public const string EmailRegularExpression = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        public const string UserTypeMechanic = "Mechanic";
        public const string UserTypeClient = "Client";
    }
}
