using GTANetworkAPI;
using RageGameMode.Domain.Shared.ApiGTA.Services;
using RageGameMode.Infrastructure.Rage.Helpers;

namespace RageGameMode.Infrastructure.Rage.Services
{
    public class NotificationService : INotificationService
    {
        public void SendMessageToPlayer(string playerName, string message)
        {
            var player = InGamePlayerSearch.GetByName(playerName);
            
            player.SendChatMessage(message);
        }

        public void PlaySoundForPlayer(string playerName, string soundName, string soundSet)
        {
            var player = InGamePlayerSearch.GetByName(playerName);
            
            NAPI.ClientEvent.TriggerClientEvent(player, "playWantedSound", soundName, soundSet);
        }
    }
}