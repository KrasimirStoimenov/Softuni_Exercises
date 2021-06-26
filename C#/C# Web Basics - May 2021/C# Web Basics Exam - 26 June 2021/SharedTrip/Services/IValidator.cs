using System.Collections.Generic;
using SharedTrip.ViewModels.Trips;
using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        public ICollection<string> ValidateUser(UserRegisterFormModel model);
        public ICollection<string> ValidateTrip(TripAddFormModel model);
    }
}
