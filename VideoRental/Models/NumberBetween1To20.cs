using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.Models
{
    public class NumberBetween1To20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.NumberInStock == null)
            {
                return new ValidationResult("The Number in stock field is required");
            }


            var numberfromRange = movie.NumberInStock;

            return (numberfromRange > 0 && numberfromRange < 21)
                ? ValidationResult.Success
                : new ValidationResult("Number must be between 1 and 20");
        }
    }
}
