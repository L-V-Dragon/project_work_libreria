using Microsoft.IdentityModel.Tokens;
using project_work_libreria.Database;
using project_work_libreria.Models;
using System.ComponentModel.DataAnnotations;

namespace project_work_libreria.CustomValidation {
    public class IsbnValidation : ValidationAttribute {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {

            string fieldvalue = (string)value;
            var item = (Libro)validationContext.ObjectInstance;
            using LibreriaContext db = new();
            var check = db.Libri.Where(x => x.Isbn == fieldvalue);

            if (item.Id == 0) {
                if (check.IsNullOrEmpty()) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult("Isbn already exists in the database");
                }
            } else {
                if (check != null || check.FirstOrDefault().Id == item.Id) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult("Isbn already exists in the database");
                }
            }
        }
    }
}
