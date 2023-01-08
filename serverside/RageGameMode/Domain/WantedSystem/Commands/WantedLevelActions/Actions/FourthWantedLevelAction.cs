namespace RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions.Actions
{
    public class FourthWantedLevelAction : ThirdWantedLevelAction
    {
        public FourthWantedLevelAction(int wantedLevel, Player.Entity.Player player, double notificationRadius) 
            : base(wantedLevel, player, notificationRadius)
        {
        }
    }
}