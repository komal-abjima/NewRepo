//using System.ComponentModel.DataAnnotations;

//namespace ModelValidations_project.CustomValidations
//{
//    public class MinimumYearValidator : ValidationAttribute
//    {
//        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//        {
//            if(value != null)
//            {
//                DateTime date = (DateTime)value;
//                if(date.Year >= 2000)
//                {
//                    return new ValidationResult
//                }
//            }
//            return base.IsValid(value, validationContext);
//        }

//    }
//}
