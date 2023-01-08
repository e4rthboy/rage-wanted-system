namespace RageGameMode.Domain.Shared.ApiGTA.Services
{
    public interface INotificationService
    {
        public void SendMessageToPlayer(string playerName, string message);

        public void PlaySoundForPlayer(string playerName, string soundName, string soundSet);
    }
}