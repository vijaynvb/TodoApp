using System.ComponentModel.DataAnnotations;

namespace TodoApp.Customization
{
    public class CustomAgeValidation : ValidationAttribute
    {
        // validation framework class

        private int _minAge;
        public CustomAgeValidation(int value)
        {
            _minAge = value;
        }
        public CustomAgeValidation() :this(18)
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // custom logic 
            if(value != null)
            {
                if(value is int)
                {
                    if((int)value < _minAge)
                    {
                        return new ValidationResult("Minimum age must be "+ _minAge.ToString());
                    }
                }
                else
                    return new ValidationResult("Minimum age should be integer value only ");
            }

            return ValidationResult.Success;
        }


    }
}
