using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                GiveBegginerPlayerAdvance(attackPlayer);
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                GiveBegginerPlayerAdvance(enemyPlayer);
            }


            GivePlayersBonusHealthPoints(attackPlayer);
            GivePlayersBonusHealthPoints(enemyPlayer);

            while (true)
            {
                Attack(attackPlayer, enemyPlayer);
                if (enemyPlayer.IsDead)
                {
                    break;
                }

                Attack(enemyPlayer, attackPlayer);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void Attack(IPlayer attacker, IPlayer defender)
        {
            var attackerDamage = 0;
            foreach (var card in attacker.CardRepository.Cards)
            {
                attackerDamage += card.DamagePoints;
            }
            defender.TakeDamage(attackerDamage);
        }
        private void GivePlayersBonusHealthPoints(IPlayer player)
        {
            foreach (var card in player.CardRepository.Cards)
            {
                player.Health += card.HealthPoints;
            }
        }
        private static void GiveBegginerPlayerAdvance(IPlayer attackPlayer)
        {
            attackPlayer.Health += 40;

            foreach (var card in attackPlayer.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
