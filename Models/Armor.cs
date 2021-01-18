using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PlainsOfPrimus.Models.MyValidations;

namespace PlainsOfPrimus.Models
{
    public class Armor
    {
        public int Id { get; set; }
        [TypeAttribute]
        public string Type { get; set; }
        [UniqueAndOfType("Type")]
        public string Name { get; set; }
        public string Image { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int ArmorValue { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Health { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Intellect { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Strength { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Agility { get; set; }

    }
}