using System.Collections.Generic;
using System.Threading.Tasks;

namespace RageGameMode.Domain.Player.Repository
{
    public interface IPlayerRepository
    {
        public Entity.Player FindBySocialClubId(string socialClubId);
        
        public Entity.Player FindByName(string name);

        public IEnumerable<Entity.Player> GetAllCops();

        public IEnumerable<Entity.Player> FindByNameList(string[] names);

        public void Save(Entity.Player player);
    }
}