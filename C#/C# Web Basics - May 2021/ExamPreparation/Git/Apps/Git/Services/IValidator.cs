using System.Collections.Generic;
using Git.ViewModels.Users;

namespace Git.Services
{
    public interface IValidator
    {
        public ICollection<string> ValidateUser(UserRegisterViewModel model);
        public ICollection<string> ValidateUserLogin(UserLoginViewModel model);
    }
}
