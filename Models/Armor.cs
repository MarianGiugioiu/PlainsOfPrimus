using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlainsOfPrimus.Models
{
    public class Armor
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ArmorValue { get; set; }
        public int Health { get; set; }
        public int Intellect { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

    }
}