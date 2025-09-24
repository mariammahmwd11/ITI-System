using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace ITI_System.Models
{
    public class uniqueName_validator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string name= value.ToString();
            ModelContext context = new ModelContext();
            var crs=context.Courses.FirstOrDefault(c => c.Name == name);
            if (crs != null)
                return new ValidationResult("name must be unique");
           
          return ValidationResult.Success;
        }
    }
}
