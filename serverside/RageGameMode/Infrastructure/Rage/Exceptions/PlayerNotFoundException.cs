using System;

namespace RageGameMode.Infrastructure.Rage.Exceptions
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException(string message = "Игрок не в сети!")
            : base(message)
        {
        }
    }
}