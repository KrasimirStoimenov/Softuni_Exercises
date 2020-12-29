using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ICollection<ICard> models;

        public CardRepository()
        {
            this.models = new List<ICard>();
        }
        public int Count => this.models.Count;

        public IReadOnlyCollection<ICard> Cards => this.models.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            if (this.models.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.models.Add(card);
        }


        public ICard Find(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            return this.models.Remove(card);
        }
    }
}
