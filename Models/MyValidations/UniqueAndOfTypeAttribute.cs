using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlainsOfPrimus.Models.MyValidations
{
    public class UniqueAndOfTypeAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;
        public UniqueAndOfTypeAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }
        private bool BeUnique(string name, int id)
        {
            var db = new ApplicationDbContext();
            var armor = db.Armors.FirstOrDefault(b => b.Name == name);
            if (armor == null || armor.Id == id)
                return true;
            return false;
        }
        private bool BeOfType(string name, string type)
        {
            string capitalizedType = char.ToUpper(type[0]) + type.Substring(1);
            return name.Contains(capitalizedType);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyName = validationContext.ObjectType.GetProperty(_otherProperty);
            var propertyValue = propertyName.GetValue(validationContext.ObjectInstance, null) as string;
            
            var armor = (Armor)validationContext.ObjectInstance;
            var name = armor.Name;
            
            if (!BeOfType(name, propertyValue))
            {
                return new ValidationResult("Name must contain the type of armor!");
            }
            if (!BeUnique(name, armor.Id))
            {
                return new ValidationResult("Name must be unique!");
            }
            return ValidationResult.Success;
        }

    }
}