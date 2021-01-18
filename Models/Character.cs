using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PlainsOfPrimus.Models.MyValidations;

namespace PlainsOfPrimus.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [TypeClassAttribute]
        public string Class { get; set; }
        [Range(0, 70, ErrorMessage = "Please enter a value between 0 and 70")]
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