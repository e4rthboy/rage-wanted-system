using System;
using GTANetworkAPI;
using RageGameMode.Domain.Auth.Commands;
using RageGameMode.Infrastructure.Database.Context;

namespace RageGameMode.Application.Handlers.Events
{
    public class GeneralEventsHandler : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            player.SendChatMessage($"Hello, ~b~{player.Name}~w~!");

            try
            {
                RegisterNewPlayerCommand.Execute(player.SocialClubId.ToString(), player.Name);
            }
            catch (Exception e)
            {
                NAPI.Util.ConsoleOutput(e.Message);
            }
            
        }
    }
}