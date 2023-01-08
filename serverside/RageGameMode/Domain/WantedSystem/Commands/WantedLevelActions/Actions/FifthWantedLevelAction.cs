using System.Linq;
using RageGameMode.Domain.Player.Repository;
using RageGameMode.Domain.Shared.ApiGTA.Services;
using RageGameMode.Domain.Shared.Enums;
using RageGameMode.Infrastructure.Database.Repositories.Player;
using RageGameMode.Infrastructure.Rage.Services;
using RageGameMode.Infrastructure.Rage.Services.Factories;

namespace RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions.Actions
{
    public class FifthWantedLevelAction : WantedLevelActionStrategy
    {
        private readonly IBlipService _blipService;
        private readonly IPlayerRepository _playerRepository;
        
        public FifthWantedLevelAction(int wantedLevel, Player.Entity.Player player) : base(wantedLevel, player)
        {
            _blipService = BlipServiceFactory.Make();
            _playerRepository = PlayerRepositoryFactory.Make();
        }
        
        protected override void ExecuteAction()
        {
            var cops = _playerRepository.GetAllCops();
            
            _blipService.CreateBlipOnPlayerForRangeOfPlayers(cops.Select(c => c.Name).ToArray(), Player.Name, BlipColors.Red);
        }

        public void CleanBlips()
        {
            var cops = _playerRepository.GetAllCops();
            
            _blipService.RemoveBlipOnPlayerForRangeOfPlayers(cops.Select(c => c.Name).ToArray(), Player.Name);
        }
    }
}