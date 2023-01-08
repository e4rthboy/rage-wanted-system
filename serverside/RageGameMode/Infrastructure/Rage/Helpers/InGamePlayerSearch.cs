using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using RageGameMode.Infrastructure.Rage.Exceptions;

namespace RageGameMode.Infrastructure.Rage.Helpers
{
    public static class InGamePlayerSearch
    {
        public static Player GetByName(string name)
        {
            var player = NAPI.Pools.GetAllPlayers().First(player => player.Name == name);

            if (player == null)
            {
                throw new PlayerNotFoundException();
            }

            return player;
        }

        public static IEnumerable<Player> GetByNames(string[] names)
        {
            var players = NAPI.Pools.GetAllPlayers().Where(player => names.Contains(player.Name));

            return players;
        }
    }
}