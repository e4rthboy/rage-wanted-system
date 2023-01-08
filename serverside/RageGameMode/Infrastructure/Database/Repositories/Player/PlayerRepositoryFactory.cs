using RageGameMode.Domain.Player.Repository;

namespace RageGameMode.Infrastructure.Database.Repositories.Player
{
    public class PlayerRepositoryFactory
    {
        public static IPlayerRepository Make()
        {
            return new PlayerRepository();
        }
    }
}