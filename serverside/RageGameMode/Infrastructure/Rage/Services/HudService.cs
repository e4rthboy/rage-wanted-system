using GTANetworkAPI;
using RageGameMode.Domain.Hud.Services;
using RageGameMode.Infrastructure.Rage.Helpers;

namespace RageGameMode.Infrastructure.Rage.Services
{
    public class HudService : IHudService
    {
        public void DrawWantedLevel(string playerName, int wantedLevel)
        {
            var player = InGamePlayerSearch.GetByName(playerName);
            
            NAPI.ClientEvent.TriggerClientEvent(player, "drawWantedLevel", wantedLevel);
        }
    }
}