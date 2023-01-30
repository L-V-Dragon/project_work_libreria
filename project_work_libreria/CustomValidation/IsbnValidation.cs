using project_work_libreria.Database;
using System.ComponentModel.DataAnnotations;

namespace project_work_libreria.CustomValidation {
    public class IsbnValidation : ValidationAttribute {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {

            string fieldvalue= (string)value;
            using LibreriaContext db = new();

            var check =db.Libri.Where(x=> x.Isbn ==fieldvalue);
            if(check == null) {
                return ValidationResult.Success;
            } else {
                return new ValidationResult("Isbn già presente nel database");
            }
        }

    }
}
