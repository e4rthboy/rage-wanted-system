using GTANetworkAPI;
using RageGameMode.Domain.Hud.Services;
using RageGameMode.Domain.Player.Repository;
using RageGameMode.Domain.Player.ValueObjects;
using RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions;
using RageGameMode.Infrastructure.Rage.Commands;

namespace RageGameMode.Domain.WantedSystem.Services
{
    public class WantedSystemService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IHudService _hudService;

        public WantedSystemService(IPlayerRepository playerRepository, IHudService hudService)
        {
            _playerRepository = playerRepository;
            _hudService = hudService;
        }

        public int GetPlayerCurrentWantedLevel(string playerName)
        {
            var player = _playerRepository.FindByName(playerName);

            return player.WantedLevel;
        }

        public void SetPlayerWantedLevel(string playerName, int wantedLevel, bool mustExecuteLevelAction = true)
        {
            var player = _playerRepository.FindByName(playerName);
            var wantedLevelValueObject = new WantedLevelValueObject(wantedLevel);
            var wantedLevelAction = WantedLevelActionStrategy.GetAction(wantedLevelValueObject.WantedLevel, player);
            
            player.SetWantedLevel(wantedLevelValueObject);
            
            _playerRepository.Save(player);
            _hudService.DrawWantedLevel(player.Name, wantedLevelValueObject.WantedLevel);
            
            wantedLevelAction.Execute(mustExecuteLevelAction);

            if (wantedLevelValueObject.WantedLevel > 0)
            {
                RegisterWantedLevelDecrease(playerName, wantedLevelValueObject.WantedLevel - 1);
            }
        }

        private void RegisterWantedLevelDecrease(string playerName, int decreasedWantedLevel)
        {
            const int delayTime = 2 * 60 * 1000; // 2 минуты

            RunDelayedTaskCommandFactory.Make().Execute(
                () => SetPlayerWantedLevel(playerName, decreasedWantedLevel, false),
                delayTime
            );
        }
    }
}