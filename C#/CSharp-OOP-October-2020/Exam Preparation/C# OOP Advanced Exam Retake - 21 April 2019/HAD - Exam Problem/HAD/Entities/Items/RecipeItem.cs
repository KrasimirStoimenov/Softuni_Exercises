using HAD.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HAD.Entities.Items
{
    public class RecipeItem : BaseItem, IRecipe
    {
        private ICollection<string> items;
        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, params string[] neededItems) : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
            this.items = new List<string>();
            AddNeededItemsForRecipe(neededItems);
        }

        public IReadOnlyList<string> RequiredItems => this.items.ToList().AsReadOnly();

        private void AddNeededItemsForRecipe(string[] neededItems)
        {
            foreach (var item in neededItems)
            {
                this.items.Add(item);
            }
        }
    }
}
