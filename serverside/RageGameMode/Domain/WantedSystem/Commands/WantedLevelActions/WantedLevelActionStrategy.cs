using System;
using RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions.Actions;
using RageGameMode.Infrastructure.Rage.Services;
using RageGameMode.Infrastructure.Rage.Services.Factories;

namespace RageGameMode.Domain.WantedSystem.Commands.WantedLevelActions
{
    /// <summary>
    /// Базовый класс стратегий, которые воспроизводят конкретное действие при назначении определенного уровня розыска.
    /// </summary>
    public abstract class WantedLevelActionStrategy
    {
        protected int WantedLevel { get; }
        
        protected Player.Entity.Player Player { get; }

        protected WantedLevelActionStrategy(int wantedLevel, Player.Entity.Player player)
        {
            WantedLevel = wantedLevel;
            Player = player;
        }

        public void Execute(bool mustExecuteAction)
        {
            if (mustExecuteAction)
            {
                ExecuteAction();
            }
            
            ExecuteCleanup();
        }
        
        protected abstract void ExecuteAction();

        /// <summary>
        /// Очистка блипа с клиента, если 5 уровень розыска упал.
        /// 
        /// Потенциально можно преобразить в более ООПшный вид)
        /// </summary>
        private void ExecuteCleanup()
        {
            if (WantedLevel < 5)
            {
                new FifthWantedLevelAction(WantedLevel, Player).CleanBlips();
            }
        }

        public static WantedLevelActionStrategy GetAction(int wantedLevel, Player.Entity.Player player)
        {
            return wantedLevel switch
            {
                0 => new NoneWantedLevelAction(0, player),
                1 => new FirstWantedLevelAction(1, player),
                2 => new SecondWantedLevelAction(2, player),
                3 => new ThirdWantedLevelAction(3, player, 20),
                4 => new FourthWantedLevelAction(4, player, 100),
                5 => new FifthWantedLevelAction(5, player),
                _ => throw new NotImplementedException("Переданного уровня розыска не существует.")
            };
        }
    }
}