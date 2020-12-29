namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private ICardFactory cardFactory;
        private IPlayerFactory playerFactory;
        private ICardRepository cardRepository;
        private IPlayerRepository playerRepository;
        private IBattleField battleField;

        public ManagerController()
        {
            this.cardFactory = new CardFactory();
            this.playerFactory = new PlayerFactory();
            this.cardRepository = new CardRepository();
            this.playerRepository = new PlayerRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);
            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);
            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);
            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Find(attackUser);
            var defender = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, defender);
            return $"Attack user health {attacker.Health} - Enemy user health {defender.Health}";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }
                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
