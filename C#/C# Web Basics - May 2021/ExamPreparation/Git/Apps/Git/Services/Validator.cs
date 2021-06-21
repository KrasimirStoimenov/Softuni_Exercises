using System.Collections.Generic;
using System.Text.RegularExpressions;
using Git.Data;
using Git.ViewModels.Repositories;
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
                errors.Add($"Username '{model.Username}' is not valid. Username should be between {DataConstants.UserUsernameMinLength} and {DataConstants.UserUsernameMaxLength} characters long.");
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
                errors.Add($"Username '{model.Username}' is not valid. Username should be between {DataConstants.UserUsernameMinLength} and {DataConstants.UserUsernameMaxLength} characters long.");
            }

            if (model.Password.Length < DataConstants.UserPasswordMinLength || model.Password.Length > DataConstants.UserPasswordMaxLength)
            {
                errors.Add($"Password is not valid. Password should be between {DataConstants.UserPasswordMinLength} and {DataConstants.UserPasswordMaxLength} characters long.");
            }

            return errors;
        }

        public ICollection<string> ValidateCreateRepository(CreateRepositoryViewModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < DataConstants.RepositoryNameMinLength || model.Name.Length > DataConstants.RepositoryNameMaxLength)
            {
                errors.Add($"Repository name '{model.Name}' is not valid. Name should be between {DataConstants.RepositoryNameMinLength} and {DataConstants.RepositoryNameMaxLength} characters long.");
            }

            if (model.RepositoryType != DataConstants.RepositoryTypePrivate && model.RepositoryType != DataConstants.RepositoryTypePublic)
            {
                errors.Add($"Repository type {model.RepositoryType} is not valid. Repository type should be either Private or Public");
            }

            return errors;
        }
    }
}
