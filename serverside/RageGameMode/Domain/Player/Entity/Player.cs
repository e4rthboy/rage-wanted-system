using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RageGameMode.Domain.Player.ValueObjects;

namespace RageGameMode.Domain.Player.Entity
{
    public class Player
    {
        [Key]
        public Guid Guid { get; private set; }
        
        public Guid? FractionId { get; set; }
        
        [Required]
        public string SocialClubId { get; private set; }
        
        [Required]
        public string Name { get; set; }

        [DefaultValue(0)]
        public int WantedLevel { get; private set; }
        
        [Required]
        public DateTime CreatedAt { get; private set; }
        
        [ForeignKey("FractionId")]
        public Fraction.Entity.Fraction? Fraction { get; set; }

        public Player(string socialClubId, string name)
        {
            Guid = Guid.NewGuid();
            SocialClubId = socialClubId;
            Name = name;
            WantedLevel = 0;
            CreatedAt = DateTime.Now;
        }

        public void SetWantedLevel(WantedLevelValueObject wantedLevel)
        {
            WantedLevel = wantedLevel.WantedLevel;
        }
    }
}