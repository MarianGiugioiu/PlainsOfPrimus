using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlainsOfPrimus.Models.MyValidations
{
    public class UniqueAchievementAttribute : ValidationAttribute
    {
        private bool BeUnique(string name, int id)
        {
            var db = new ApplicationDbContext();
            var armor = db.Achievements.FirstOrDefault(b => b.Name == name);
            if (armor == null || armor.Id == id)
                return true;
            return false;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var achievement = (Achievement)validationContext.ObjectInstance;
            var name = achievement.Name;
            var id = achievement.Id;

            if (!BeUnique(name, id))
            {
                return new ValidationResult("Name must be unique!");
            }
            return ValidationResult.Success;
        }
    }
}