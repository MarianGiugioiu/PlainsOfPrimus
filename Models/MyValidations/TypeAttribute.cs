using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlainsOfPrimus.Models.MyValidations
{
    public class TypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var armor = (Armor)validationContext.ObjectInstance;
            var type = armor.Type;

            if (type != "chestplate" && type != "helmet" && type != "leggings" && type != "boots")
            {
                return new ValidationResult("Type must be one of the following: helmet, chestplate, leggings or boots!");
            }
            return ValidationResult.Success;
        }
    }
}