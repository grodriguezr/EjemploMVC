using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploMVC.Models
{
    public class DetallesUsuario
    {
        [StringLength(7, MinimumLength = 2, ErrorMessage = "La cantidad de caracteres del nombre de ususario debe estar entre 2 y 7")]
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}