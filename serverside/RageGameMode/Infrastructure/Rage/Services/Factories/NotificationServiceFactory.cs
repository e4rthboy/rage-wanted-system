using RageGameMode.Domain.Shared.ApiGTA.Services;

namespace RageGameMode.Infrastructure.Rage.Services.Factories
{
    public class NotificationServiceFactory
    {
        public static INotificationService Make()
        {
            return new NotificationService();
        }
    }
}