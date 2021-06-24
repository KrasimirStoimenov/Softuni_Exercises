using System.Collections.Generic;
using BattleCards.ViewModels.Cards;
using BattleCards.ViwModels.Users;

namespace BattleCards.Services
{
    public interface IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model);
        public ICollection<string> ValidateCard(AddCardFormModel model);
    }
}
