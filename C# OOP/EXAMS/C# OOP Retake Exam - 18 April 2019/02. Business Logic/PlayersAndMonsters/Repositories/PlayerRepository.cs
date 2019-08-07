using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> playersByName;

        public PlayerRepository()
        {
            playersByName = new Dictionary<string, IPlayer>();
        }

        public int Count => this.playersByName.Count;

        public IReadOnlyCollection<IPlayer> Players => this.playersByName.Values.ToList();

        public void Add(IPlayer player)
        {
            ThrowIfPlayerDoesntExist(player, "Player cannot be null");

            if (playersByName.ContainsKey(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            playersByName.Add(player.Username, player);
        }

       

        public IPlayer Find(string username)
        {
            IPlayer player = null;
            if (this.playersByName.ContainsKey(username))
            {
                player = this.playersByName[username];
            }
            return player;
        }

        public bool Remove(IPlayer player)
        {
            ThrowIfPlayerDoesntExist(player, "Player cannot be null");
            bool isDelete= playersByName.Remove(player.Username);
            return isDelete;
        }

        private static void ThrowIfPlayerDoesntExist(IPlayer player, string message)
        {
            if (player == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
