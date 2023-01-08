using System.Linq;
using GTANetworkAPI;
using RageGameMode.Domain.Fraction.Enum;
using RageGameMode.Domain.Player.Repository;
using RageGameMode.Domain.Shared.ApiGTA.Services;
using RageGameMode.Infrastructure.Database.Repositories.Player;
using RageGameMode.Infrastructure.Rage.Services.Factories;

namespace RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions.Actions
{
    public class ThirdWantedLevelAction : WantedLevelActionStrategy
    {
        protected double NotificationRadius;
        
        private readonly INotificationService _notificationService;
        private readonly IPlayerService _playerService;
        private readonly IPlayerRepository _playerRepository;
        
        public ThirdWantedLevelAction(int wantedLevel, Player.Entity.Player player, double notificationRadius) : base(wantedLevel, player)
        {
            NotificationRadius = notificationRadius;
            
            _notificationService = NotificationServiceFactory.Make();
            _playerService = PlayerServiceFactory.Make();
            _playerRepository = PlayerRepositoryFactory.Make();
        }
        
        protected override void ExecuteAction()
        {
            var playerNamesInRadius = _playerService.GetPlayerNamesInRadiusOfGivenPlayer(Player.Name, NotificationRadius);
            var potentialCops = _playerRepository.FindByNameList(playerNamesInRadius.ToArray());

            foreach (var potentialCop in potentialCops)
            {
                if (potentialCop.Fraction?.Type == FractionTypeEnum.Legal)
                {
                    _notificationService.SendMessageToPlayer(potentialCop.Name, $"~r~Где-то в ~w~{NotificationRadius}~r~ метрах от вас совершили преступление!");
                }
            }
        }
    }
}