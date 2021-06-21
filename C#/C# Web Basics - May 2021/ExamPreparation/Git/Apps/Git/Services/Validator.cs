using System.Collections.Generic;
using System.Text.RegularExpressions;
using Git.Data;
using Git.ViewModels.Users;

namespace Git.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(UserRegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < DataConstants.UserUsernameMinLength || model.Username.Length > DataConstants.UserUsernameMaxLength)
            {
                errors.Add($"Username {model.Username} is not valid. Username should be between {DataConstants.UserUsernameMinLength} and {DataConstants.UserUsernameMaxLength} characters long.");
            }

            if (model.Password.Length < DataConstants.UserPasswordMinLength || model.Password.Length > DataConstants.UserPasswordMaxLength)
            {
                errors.Add($"Password is not valid. Password should be between {DataConstants.UserPasswordMinLength} and {DataConstants.UserPasswordMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, DataConstants.EmailRegularExpression))
            {
                errors.Add($"The input is not valid email address.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and confirm password are not the same.");
            }

            return errors;
        }

        public ICollection<string> ValidateUserLogin(UserLoginViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < DataConstants.UserUsernameMinLength || model.Username.Length > DataConstants.UserUsernameMaxLength)
            {
                errors.Add($"Username {model.Username} is not valid. Username should be between {DataConstants.UserUsernameMinLength} and {DataConstants.UserUsernameMaxLength} characters long.");
            }

            if (model.Password.Length < DataConstants.UserPasswordMinLength || model.Password.Length > DataConstants.UserPasswordMaxLength)
            {
                errors.Add($"Password is not valid. Password should be between {DataConstants.UserPasswordMinLength} and {DataConstants.UserPasswordMaxLength} characters long.");
            }

            return errors;
        }
    }
}
