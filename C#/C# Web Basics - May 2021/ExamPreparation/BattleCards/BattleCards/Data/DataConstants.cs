using System;
using System.Collections.Generic;

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
        public const int CardMinimalAttack = 0;
        public const int CardMinimalHealth = 0;
        public const string CardKeywordValueTough = "Tough";
        public const string CardKeywordValueChallenger = "Challenger";
        public const string CardKeywordValueElusive = "Elusive";
        public const string CardKeywordValueOverwhelm = "Overwhelm";
        public const string CardKeywordValueLifesteal = "Lifesteal";
        public const string CardKeywordValueEphemeral = "Ephemeral";
        public const string CardKeywordValueFearsome = "Fearsome";
    }
}
