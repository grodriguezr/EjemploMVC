using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploMVC.Models;
using EjemploMVC.ViewModels;

namespace EjemploMVC.Controllers
{
    public class Customer
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public override string ToString()
        {
            return this.Nombre + " | " + this.Direccion;
        }

        
    }

    public class EmpleadoController : Controller
    {
        public string GetString()
        {
            return "Hola mundo";
        }

        public Customer GetCustomer()
        {
            Customer c = new Customer()
            {
                Nombre = "Gustavo Rodríguez",
                Direccion = "Tv 80a No 80 - 75"
            };
            return c;
        }

        [Authorize]
        public ActionResult Index()
        {
            //Empleado e = new Empleado()
            //{
            //    FirstName = "Gustavo",
            //    LastName = "Rodríguez",
            //    Salario = 10000
            //};

            //EmpleadoViewModel evm = new EmpleadoViewModel();
            //evm.NombreEmpleado = e.FirstName + " " + e.LastName;
            //evm.Salario = e.Salario.ToString("C");
            //evm.SalarioColor = e.Salario > 15000 ? "yellow" : "green";

            ListaEmpleadoViewModel empleadosViewModel = new ListaEmpleadoViewModel();
            EmpleadoBusinessLayer empbl = new EmpleadoBusinessLayer();
            List <Empleado> listaEmpleados = empbl.GetEmpleados();
            List<EmpleadoViewModel> listaEmpleadoViewModel = new List<EmpleadoViewModel>();
            foreach (var item in listaEmpleados)
            {
                EmpleadoViewModel empleadoViewModel = new EmpleadoViewModel();
                empleadoViewModel.NombreEmpleado = item.FirstName + " " + item.LastName;
                empleadoViewModel.Salario = item.Salario.ToString("C");
                empleadoViewModel.SalarioColor = item.Salario > 15000 ? "yellow" : "green";
                empleadosViewModel.NombreUsuario = User.Identity.Name;
                listaEmpleadoViewModel.Add(empleadoViewModel);
            }
            empleadosViewModel.Empleados = listaEmpleadoViewModel;
            //empleadosViewModel.NombreUsuario = "Admin";
            
            return View("Index", empleadosViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CrearEmpleado", new CrearEmpleadoViewModel());
        }
        public ActionResult GuardarEmpleado(Empleado e, string BtnSubmit)
        {
            //return e.FirstName + "|" + e.LastName + "|" + e.Salario;

            switch (BtnSubmit)
            {
                case "Guardar":
                    if (ModelState.IsValid)
                    {
                        //return Content(e.FirstName + "|" + e.LastName + "|" + e.Salario);
                        EmpleadoBusinessLayer empBL = new EmpleadoBusinessLayer();
                        empBL.GuardarEmpleado(e);
                        return RedirectToAction("Index");
                    }else
                    {
                        CrearEmpleadoViewModel cvm = new CrearEmpleadoViewModel();
                        cvm.FirstName = e.FirstName;
                        cvm.LastName = e.LastName;
                        cvm.Salario = e.Salario.ToString();
                        return View("CrearEmpleado", cvm);
                    }
                case "Cancelar":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}