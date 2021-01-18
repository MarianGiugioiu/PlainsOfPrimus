using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PlainsOfPrimus.Models.MyValidations;

namespace PlainsOfPrimus.Models
{
    public class Achievement
    {
        public int Id { get; set; }
        [UniqueAchievementAttribute]
        public string Name { get; set; }
        [MinLength(1, ErrorMessage = "Requirements cannot have length less than 1!")]
        public string Requirements { get; set; }
        [Range(10, 100, ErrorMessage = "Please enter a value between 10 and 100")]
        public int Points { get; set; }
        public List<Character> Characters { get; set; }
    }
}