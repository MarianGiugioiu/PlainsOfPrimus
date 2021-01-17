using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlainsOfPrimus.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Helmet { get; set; }
        public Armor Chestplate { get; set; }
        public Armor Leggings { get; set; }
        public Armor Boots { get; set; }
        public List<Achievement> Achievements { get; set; }
        public string UserId { get; set; }

    }
}