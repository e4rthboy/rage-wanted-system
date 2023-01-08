using GTANetworkAPI;
using RageGameMode.Domain.Shared.Enums;
using RageGameMode.Domain.WantedSystem.Services;
using RageGameMode.Infrastructure.Database.Repositories.Player;
using RageGameMode.Infrastructure.Rage.Services;

namespace RageGameMode.Application.Handlers.Commands
{
    public class CommandHandler : Script
    {
        private readonly WantedSystemService _wantedSystemService;
        
        public CommandHandler()
        {
            _wantedSystemService = new WantedSystemService(PlayerRepositoryFactory.Make(), new HudService());
        }

        [Command("set_wanted_level", "/set_wanted_level [Player name] [0-5]")]
        private void OnSetWantedLevelCommand(Player player, string playerName, int wantedLevel)
        {
            _wantedSystemService.SetPlayerWantedLevel(playerName, wantedLevel);
        }

        [Command("get_wanted_level", "/get_wanted_level [Player name]")]
        private void GetWantedLevelCommand(Player player, string playerName)
        {
            var level = _wantedSystemService.GetPlayerCurrentWantedLevel(playerName);
            player.SendChatMessage($"Уровень розыска игрока: {level}");
        }
    }
}