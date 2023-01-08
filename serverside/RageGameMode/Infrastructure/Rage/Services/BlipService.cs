using GTANetworkAPI;
using RageGameMode.Domain.Shared.ApiGTA.Services;
using RageGameMode.Infrastructure.Rage.Helpers;

namespace RageGameMode.Infrastructure.Rage.Services
{
    public class BlipService : IBlipService
    {
        public void CreateBlipOnPlayerForRangeOfPlayers(string[] playerNames, string targetName, int blipColor)
        {
            var target = InGamePlayerSearch.GetByName(targetName);
            var players = InGamePlayerSearch.GetByNames(playerNames);
            
            foreach (var player in players)
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "addPlayerBlip", target, blipColor);
            }
        }
        
        public void RemoveBlipOnPlayerForRangeOfPlayers(string[] playerNames, string targetName)
        {
            var target = InGamePlayerSearch.GetByName(targetName);
            var players = InGamePlayerSearch.GetByNames(playerNames);
            
            foreach (var player in players)
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "removePlayerBlip", target);
            }
        }
    }
}