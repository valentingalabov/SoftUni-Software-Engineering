using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

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

            if (attackPlayer is Beginner)
            {

                this.BoostBeginnerPlayer(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                this.BoostBeginnerPlayer(enemyPlayer);
            }

            this.BoostPlayer(attackPlayer);
            this.BoostPlayer(enemyPlayer);

            var attackPlayerDamage = attackPlayer
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);

            var enemyPlayerDamage = enemyPlayer
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }
                attackPlayer.TakeDamage(enemyPlayerDamage);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private  void BoostPlayer(IPlayer player)
        {
            var attackPlayerBonusHealth = player
                            .CardRepository
                            .Cards
                            .Sum(c => c.HealthPoints);

            player.Health += attackPlayerBonusHealth;
        }

        private void BoostBeginnerPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
