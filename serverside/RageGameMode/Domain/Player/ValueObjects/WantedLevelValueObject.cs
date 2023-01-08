using RageGameMode.Domain.Shared.Exceptions;

namespace RageGameMode.Domain.Player.ValueObjects
{
    public class WantedLevelValueObject
    {
        public int WantedLevel { get; }

        public WantedLevelValueObject(int wantedLevel)
        {
            wantedLevel = GetCorrectValue(wantedLevel);
            WantedLevel = wantedLevel;
        }

        private int GetCorrectValue(int wantedLevel)
        {
            if (wantedLevel < 0)
            {
                return 0;
            }

            if (wantedLevel > 5)
            {
                return 5;
            }

            return wantedLevel;
        }
    }
}