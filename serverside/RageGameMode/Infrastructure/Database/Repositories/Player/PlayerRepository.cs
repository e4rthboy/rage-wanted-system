using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RageGameMode.Domain.Fraction.Enum;
using RageGameMode.Domain.Player.Repository;
using RageGameMode.Infrastructure.Database.Context;

namespace RageGameMode.Infrastructure.Database.Repositories.Player
{
    public class PlayerRepository : IPlayerRepository
    {
        public Domain.Player.Entity.Player FindBySocialClubId(string socialClubId)
        {
            using var context = new ApplicationContext();

            return context.Players.First(player => player.SocialClubId == socialClubId);
        }

        public Domain.Player.Entity.Player FindByName(string name)
        {
            using var context = new ApplicationContext();

            return context.Players.First(player => player.Name == name);
        }

        public IEnumerable<Domain.Player.Entity.Player> GetAllCops()
        {
            using var context = new ApplicationContext();

            return context.Players.Where(player => player.Fraction != null && player.Fraction.Type == FractionTypeEnum.Legal).AsEnumerable();
        }

        public IEnumerable<Domain.Player.Entity.Player> FindByNameList(string[] names)
        {
            using var context = new ApplicationContext();

            return context.Players.Where(player => names.Contains(player.Name)).AsEnumerable();
        }

        public void Save(Domain.Player.Entity.Player player)
        {
            using var context = new ApplicationContext();
            
            if (context.Players.Any(p => p.Guid == player.Guid))
            {
                context.Players.Update(player);
            }
            else
            {
                context.Players.Add(player);
            }

            context.SaveChanges();
        }
    }
}