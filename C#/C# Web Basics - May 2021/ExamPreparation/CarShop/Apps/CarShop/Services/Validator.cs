using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CarShop.Data;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Users;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < DataConstants.UserUsernameMinLength || model.Username.Length > DataConstants.DefaultMaxLength)
            {
                errors.Add($"Username {model.Username} is not valid. It must be between {DataConstants.UserUsernameMinLength} and {DataConstants.DefaultMaxLength} characters long.");
            }

            if (model.Password.Length < DataConstants.UserPasswordMinLength || model.Password.Length > DataConstants.DefaultMaxLength)
            {
                errors.Add($"Password is not valid. It must be between {DataConstants.UserUsernameMinLength} and {DataConstants.DefaultMaxLength} characters long.");
            }

            if (model.ConfirmPassword != model.Password)
            {
                errors.Add($"Confirm password does not match original password.");
            }

            if (!Regex.IsMatch(model.Email, DataConstants.EmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not valid Email address.");
            }

            if (model.UserType != DataConstants.UserTypeMechanic && model.UserType != DataConstants.UserTypeClient)
            {
                errors.Add("User type is not valid. Should be either mechanic or client");
            }

            return errors;
        }
        public ICollection<string> ValidateCar(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < DataConstants.CarModelMinLength || model.Model.Length > DataConstants.DefaultMaxLength)
            {
                errors.Add($"Model {model.Model} is not valid. It must be between {DataConstants.CarModelMinLength} and {DataConstants.DefaultMaxLength} characters long.");
            }

            if (model.Year < 1900 || model.Year > DateTime.Now.Year)
            {
                errors.Add($"Year {model.Year} is not valid. It must be between 1900 and {DateTime.Now.Year} characters long.");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image {model.Image} is not valid URL");
            }

            if (!Regex.IsMatch(model.PlateNumber, DataConstants.PlateNumberValidatorRegex))
            {
                errors.Add($"Plate Number {model.PlateNumber} is not valid. It must be in format 'AA 0000 AA'");
            }

            return errors;
        }

    }
}
