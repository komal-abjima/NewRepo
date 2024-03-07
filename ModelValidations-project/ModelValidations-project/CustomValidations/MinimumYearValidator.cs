using System.ComponentModel.DataAnnotations;

namespace ModelValidations_project.CustomValidations
{
    public class MinimumYearValidator : ValidationAttribute
    {
        public int MinimumYear { get; set; }
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";

        public MinimumYearValidator()
        {
            
        }

        public MinimumYearValidator(int minimumYear)
        {
            MinimumYear = minimumYear;  
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= 2000)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }

    }
}
