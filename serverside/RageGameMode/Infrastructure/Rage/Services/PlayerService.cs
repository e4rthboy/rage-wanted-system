using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using RageGameMode.Domain.Shared.ApiGTA.Services;
using RageGameMode.Infrastructure.Rage.Helpers;

namespace RageGameMode.Infrastructure.Rage.Services
{
    public class PlayerService : IPlayerService
    {
        public IEnumerable<string> GetPlayerNamesInRadiusOfGivenPlayer(string playerName, double radius)
        {
            var player = InGamePlayerSearch.GetByName(playerName);

            return NAPI.Player.GetPlayersInRadiusOfPlayer(radius, player).Select(p => p.Name);
        }
    }
}