namespace RageGameMode.Domain.Shared.ApiGTA.Services
{
    public interface IBlipService
    {
        public void CreateBlipOnPlayerForRangeOfPlayers(string[] playerNames, string targetName, int blipColor);

        public void RemoveBlipOnPlayerForRangeOfPlayers(string[] playerNames, string targetName);
    }
}