using System;
using RageGameMode.Infrastructure.Database.Repositories.Player;

namespace RageGameMode.Domain.Auth.Commands
{
    /// <summary>
    /// Создает запись об игроке при входе на сервер
    /// </summary>
    public class RegisterNewPlayerCommand
    {
        public static void Execute(string socialClubId, string name)
        {
            var repository = PlayerRepositoryFactory.Make();

            try
            {
                repository.FindByName(name);
            }
            catch (Exception)
            {
                var newPlayer = new Player.Entity.Player(socialClubId, name);
                repository.Save(newPlayer);
            }
        }
    }
}