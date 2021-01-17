using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlainsOfPrimus.Models
{
    public class CharacterViewModel
    {
        public Character Character { get; set; }
        public List<Weapon> Weapons { get; set; }

    }
}