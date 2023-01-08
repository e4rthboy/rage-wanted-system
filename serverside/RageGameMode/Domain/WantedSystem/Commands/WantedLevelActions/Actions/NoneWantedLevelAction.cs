namespace RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions.Actions
{
    public class NoneWantedLevelAction : WantedLevelActionStrategy
    {
        public NoneWantedLevelAction(int wantedLevel, Player.Entity.Player player) : base(wantedLevel, player)
        {
        }
        
        protected override void ExecuteAction()
        {
            // none
        }
    }
}