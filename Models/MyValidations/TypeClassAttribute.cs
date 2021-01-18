using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlainsOfPrimus.Models.MyValidations
{
    public class TypeClassAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var character = (Character)validationContext.ObjectInstance;
            var type = character.Class;

            if (type != "warrior" && type != "wizard" && type != "assassin")
            {
                return new ValidationResult("Class must be one of the following: warrior, wizard, or assassin!");
            }
            return ValidationResult.Success;
        }
    }
}