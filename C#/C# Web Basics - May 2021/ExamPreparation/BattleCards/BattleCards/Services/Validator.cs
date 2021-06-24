using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BattleCards.Data;
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
    }
}
