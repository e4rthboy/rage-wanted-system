using System;
using GTANetworkAPI;
using RageGameMode.Domain.Shared.ApiGTA.Commands;

namespace RageGameMode.Infrastructure.Rage.Commands
{
    public class RunDelayedTaskCommand : IRunDelayedTaskCommand
    {
        public void Execute(Action task, int delayTime)
        {
            NAPI.Task.Run(task, delayTime);
        }
    }
}