using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploMVC.Validaciones
{
    public class ValidacionNombre:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)//si el valor está llegando vacío
            {
                return new ValidationResult("Por favor escriba el nombre");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("EL nombre no debe contener el caracter @");
                }
            }
            return ValidationResult.Success;
        }
    }
}