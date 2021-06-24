using System.Collections.Generic;
using BattleCards.ViwModels.Users;

namespace BattleCards.Services
{
    public interface IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model);
    }
}
