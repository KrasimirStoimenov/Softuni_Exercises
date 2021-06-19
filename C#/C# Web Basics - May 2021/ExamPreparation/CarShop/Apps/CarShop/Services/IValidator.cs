using System.Collections.Generic;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;
using CarShop.ViewModels.Users;

namespace CarShop.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateCar(AddCarFormModel model);
        ICollection<string> ValidateIssue(AddIssueFormModel model);
    }
}
