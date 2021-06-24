using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BattleCards.Data;
using BattleCards.ViewModels.Cards;
using BattleCards.ViwModels.Users;

namespace BattleCards.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. Username should be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (model.Username.Any(c => !char.IsLetterOrDigit(c)))
            {
                errors.Add($"Username '{model.Username}' is not valid. Username should contains only letters and digits.");
            }

            if (model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password is not valid. Password should be between {PasswordMinLength} and {PasswordMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and confirm password are not identical.");
            }

            if (!Regex.IsMatch(model.Email, EmailRegularExpression))
            {
                errors.Add("Entered email is not valid email address.");
            }

            return errors;
        }

        public ICollection<string> ValidateCard(AddCardFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < CardNameMinLength || model.Name.Length > CardNameMaxLength)
            {
                errors.Add($"Card name '{model.Name}' is not valid. Card name should be between {CardNameMinLength} and {CardNameMaxLength} characters long.");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add("Provided invalid image Url.");
            }

            if (model.Keyword != CardKeywordValueChallenger && model.Keyword != CardKeywordValueElusive && model.Keyword != CardKeywordValueEphemeral && model.Keyword != CardKeywordValueFearsome && model.Keyword != CardKeywordValueLifesteal && model.Keyword != CardKeywordValueOverwhelm && model.Keyword != CardKeywordValueTough)
            {
                errors.Add("Provided keyword is not supported.");
            }

            if (model.Attack < CardMinimalAttack)
            {
                errors.Add("Attack should be positive number");
            }
            
            if (model.Health < CardMinimalHealth)
            {
                errors.Add("Health should be positive number");
            }

            if(model.Description.Length > CardDescriptionMaxLength)
            {
                errors.Add($"Description should be maximum {CardDescriptionMaxLength} characters long.");
            }

            return errors;
        }
    }
}
