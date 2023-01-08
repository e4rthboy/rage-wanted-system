using RageGameMode.Domain.Shared.ApiGTA.Services;
using RageGameMode.Domain.Shared.Enums;
using RageGameMode.Infrastructure.Rage.Services.Factories;

namespace RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions.Actions
{
    public class SecondWantedLevelAction : WantedLevelActionStrategy
    {
        private readonly INotificationService _notificationService;

        public SecondWantedLevelAction(int wantedLevel, Player.Entity.Player player) : base(wantedLevel, player)
        {
            _notificationService = NotificationServiceFactory.Make();
        }

        protected override void ExecuteAction()
        {
            var sound = SoundsEnum.WantedSound;
            _notificationService.PlaySoundForPlayer(Player.Name, sound.SoundName, sound.SoundSet);
        }
    }
}