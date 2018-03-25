using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EjemploMVC.Models
{
    public class Empleado
    {
        [Key]
        public int IDEmpleado { get; set; }

        //[Required(ErrorMessage = "Ingrese el nombre")]
        [Validaciones.ValidacionNombre]
        public string FirstName { get; set; }

        [StringLength(5, ErrorMessage = "La cantidad de caracteres del apellido no debe ser mayor a 5")]
        public string LastName { get; set; }
        public int Salario { get; set; }
    }
}