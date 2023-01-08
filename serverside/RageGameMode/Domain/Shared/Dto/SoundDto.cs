namespace RageGameMode.Domain.Shared.Dto
{
    public class SoundDto
    {
        public string SoundName { get; }
        public string SoundSet { get; }
        
        public SoundDto(string soundName, string soundSet)
        {
            SoundName = soundName;
            SoundSet = soundSet;
        }
    }
}