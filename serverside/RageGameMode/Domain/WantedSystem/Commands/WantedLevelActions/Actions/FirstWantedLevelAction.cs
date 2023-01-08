using RageGameMode.Infrastructure.Rage.Services;

namespace RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions.Actions
{
    public class FirstWantedLevelAction : WantedLevelActionStrategy
    {
        public FirstWantedLevelAction(int wantedLevel, Player.Entity.Player player) : base(wantedLevel, player)
        {
        }

        protected override void ExecuteAction()
        {
            // doing nothing
        }
    }
}