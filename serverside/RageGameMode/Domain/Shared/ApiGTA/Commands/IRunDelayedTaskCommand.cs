using System;

namespace RageGameMode.Domain.Shared.ApiGTA.Commands
{
    public interface IRunDelayedTaskCommand
    {
        public void Execute(Action task, int delayTime);
    }
}