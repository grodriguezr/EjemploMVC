using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploMVC.ViewModels
{
    public class ListaEmpleadoViewModel
    {
        public List<EmpleadoViewModel> Empleados { get; set; }
        public string NombreUsuario { get; set; }
    }
}