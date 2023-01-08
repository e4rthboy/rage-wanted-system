using RageGameMode.Domain.Shared.ApiGTA.Services;

namespace RageGameMode.Infrastructure.Rage.Services.Factories
{
    public class PlayerServiceFactory
    {
        public static IPlayerService Make()
        {
            return new PlayerService();
        }
    }
}