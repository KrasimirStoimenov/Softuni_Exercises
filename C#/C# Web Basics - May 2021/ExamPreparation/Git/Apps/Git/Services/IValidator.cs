using System.Collections.Generic;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;

namespace Git.Services
{
    public interface IValidator
    {
        public ICollection<string> ValidateUser(UserRegisterViewModel model);
        public ICollection<string> ValidateUserLogin(UserLoginViewModel model);
        public ICollection<string> ValidateCreateRepository(CreateRepositoryViewModel model);
        public ICollection<string> ValidateCommitCreateModel(CreateCommitFormModel model);
    }
}
