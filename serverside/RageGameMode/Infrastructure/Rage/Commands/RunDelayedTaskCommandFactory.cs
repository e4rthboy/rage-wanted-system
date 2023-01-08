using RageGameMode.Domain.Shared.ApiGTA.Commands;

namespace RageGameMode.Infrastructure.Rage.Commands
{
    public class RunDelayedTaskCommandFactory
    {
        public static IRunDelayedTaskCommand Make()
        {
            return new RunDelayedTaskCommand();
        }
    }
}