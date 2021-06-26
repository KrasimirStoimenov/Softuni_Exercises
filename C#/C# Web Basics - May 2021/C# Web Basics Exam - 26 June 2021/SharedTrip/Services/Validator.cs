using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SharedTrip.Data;
using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services
{
    using static DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(UserRegisterFormModel model)
        {
            var errorList = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errorList.Add($"Username '{model.Username}' is not valid. Username should be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (model.Username.Any(c => char.IsWhiteSpace(c)))
            {
                errorList.Add("Username should not contain whitespaces");
            }

            if (!Regex.IsMatch(model.Email, EmailRegexValidator))
            {
                errorList.Add("Input email is not valid email address.");
            }

            if (model.Password.Length < PasswordMinLength || model.Password.Length > PasswordMaxLength)
            {
                errorList.Add($"Password is not valid. Password should be between {PasswordMinLength} and {PasswordMaxLength} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errorList.Add("Password and confirm password are not identical.");
            }

            return errorList;
        }

        public ICollection<string> ValidateTrip(TripAddFormModel model)
        {
            var errorList = new List<string>();

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                errorList.Add("Start point is not valid location.");
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                errorList.Add("End point is not valid location.");
            }

            if (model.Seats < TripSeatsMinValue || model.Seats > TripSeatsMaxValue)
            {
                errorList.Add($"Seats should be between {TripSeatsMinValue} and {TripSeatsMaxValue}");
            }

            if (model.Description.Length > TripDescriptionMaxLength)
            {
                errorList.Add("Description is too long.");
            }

            return errorList;
        }
    }
}
