using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlainsOfPrimus.Models
{
    public class CharacterViewModel
    {
        public Character Character { get; set; }
        public int WeaponId { get; set; }
        public int HelmetId { get; set; }
        public int ChestplateId { get; set; }
        public int LeggingsId { get; set; }
        public int BootsId { get; set; }
        public int[] AchievementIds { get; set; }
        public IEnumerable<SelectListItem> Weapons { get; set; }
        public IEnumerable<SelectListItem> Helmets { get; set; }
        public IEnumerable<SelectListItem> Chestplates { get; set; }
        public IEnumerable<SelectListItem> Leggings { get; set; }
        public IEnumerable<SelectListItem> Boots { get; set; }
        public IEnumerable<SelectListItem> Achievements { get; set; }


    }
}