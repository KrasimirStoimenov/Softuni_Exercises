using System.Collections.Generic;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Users;

namespace CarShop.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
        ICollection<string> ValidateCar(AddCarFormModel model);
    }
}
