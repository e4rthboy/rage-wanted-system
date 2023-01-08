using System;
using System.ComponentModel.DataAnnotations;
using RageGameMode.Domain.Fraction.Enum;

namespace RageGameMode.Domain.Fraction.Entity
{
    public class Fraction
    {
        [Key]
        public Guid Guid { get; private set; }
        
        [Required]
        public string Name { get; private set; }
        
        [Required]
        public FractionTypeEnum Type { get; private set; }
        
        [Required]
        public DateTime CreatedAt { get; private set; }

        public static Fraction Make(string name, FractionTypeEnum type)
        {
            return new Fraction()
            {
                Name = name,
                Type = type
            };
        }
    }
}