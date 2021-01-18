using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlainsOfPrimus.Models.MyValidations;
using System.ComponentModel.DataAnnotations;

namespace PlainsOfPrimus.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        [UniqueWeaponAttribute]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int AttackDamage { get; set; }
        [MinLength(1, ErrorMessage = "Special Bonus cannot have length less than 1!")]
        public string SpecialBonus { get; set; }

    }
}