using System.ComponentModel.DataAnnotations;
using System.Net;

namespace project_work_libreria.CustomValidation
{
    public class ImageUrlValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string ErrorMessage = "il link inserito non è valido";

            if (value == null)
            {
                return new ValidationResult("campo obbligatorio");
            }

            string FieldValue = (string)value;
            WebRequest webRequest;

            try
            {
                webRequest = WebRequest.Create(FieldValue);
            }
            catch (Exception e)
            {
                return new ValidationResult(ErrorMessage);
            }
            WebResponse webResponse;

            try
            {
                webResponse = webRequest.GetResponse();
                if (webResponse.ContentType.StartsWith("image/"))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage);
            }
            catch (Exception ex)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}
