using RageGameMode.Domain.Shared.ApiGTA.Services;

namespace RageGameMode.Infrastructure.Rage.Services.Factories
{
    public class BlipServiceFactory
    {
        public static IBlipService Make()
        {
            return new BlipService();
        }
    }
}