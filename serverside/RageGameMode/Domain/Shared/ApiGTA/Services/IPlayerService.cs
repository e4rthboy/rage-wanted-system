using System.Collections.Generic;

namespace RageGameMode.Domain.Shared.ApiGTA.Services
{
    public interface IPlayerService
    {
        public IEnumerable<string> GetPlayerNamesInRadiusOfGivenPlayer(string playerName, double radius);
    }
}