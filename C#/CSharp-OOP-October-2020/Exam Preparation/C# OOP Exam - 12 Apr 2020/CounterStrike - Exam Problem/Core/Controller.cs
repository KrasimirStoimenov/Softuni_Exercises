using System;
using System.Linq;

using CounterStrike.Models.Maps;
using CounterStrike.Repositories;
using CounterStrike.Core.Contracts;
using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository gunRepository;
        private readonly PlayerRepository playerRepository;
        private readonly IMap map;
        public Controller()
        {
            this.gunRepository = new GunRepository();
            this.playerRepository = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.gunRepository.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = gunRepository.Models.FirstOrDefault(x => x.Name == gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;
            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }

            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            playerRepository.Add(player);
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in playerRepository.Models
                                                    .OrderBy(x => x.GetType().Name)
                                                    .ThenByDescending(x => x.Health)
                                                    .ThenBy(n => n.Username))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            Map map = new Map();
            var validPlayers = playerRepository.Models.Where(x => x.IsAlive == true).ToList();
            return map.Start(validPlayers);
        }
    }
}
