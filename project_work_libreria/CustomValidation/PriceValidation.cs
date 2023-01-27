using System.ComponentModel.DataAnnotations;

namespace project_work_libreria.CustomValidation
{
    public class PriceValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string FieldValue) return new ValidationResult("Errore");
            try
            {
                double x = double.Parse(FieldValue);
                if (x < 0)
                {
                    return new ValidationResult("Hai inserito un prezzo non possibile");
                }

                return ValidationResult.Success;
            }
            catch (Exception ex)
            {
                return new ValidationResult("Non hai inserito dei numeri");
            }
        }
}
