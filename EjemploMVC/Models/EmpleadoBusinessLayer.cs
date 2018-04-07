using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EjemploMVC.DataAccessLayer;

namespace EjemploMVC.Models
{
    public class EmpleadoBusinessLayer
    {
        public List<Empleado> GetEmpleados()
        {
            //List<Empleado> Empleados = new List<Empleado>();
            //Empleado emp = new Empleado();
            //emp.FirstName = "Jonh";
            //emp.LastName = "Doe";
            //emp.Salario = 178000;
            //Empleados.Add(emp);

            //emp = new Empleado();
            //emp.FirstName = "Michael";
            //emp.LastName = "Jackson";
            //emp.Salario = 10000000;
            //Empleados.Add(emp);

            //emp = new Empleado();
            //emp.FirstName = "Mariel";
            //emp.LastName = "Rodríguez";
            //emp.Salario = 10000;
            //Empleados.Add(emp);

            SalesERPDAL salesDal = new SalesERPDAL();

            return salesDal.empleados.ToList();

        }
        
        public Empleado GuardarEmpleado(Empleado e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.empleados.Add(e);
            salesDal.SaveChanges();
            return e;
        }
        //public bool UsuarioEsValido(DetallesUsuario d)
        //{
        //    if (d.NombreUsuario == "Admin" && d.Contrasena == "Admin")
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public EstadoUsuario GetUserValidity(DetallesUsuario d)
        {
            if(d.NombreUsuario == "Admin" && d.Contrasena == "Admin")
            {
                return EstadoUsuario.AdminAutenticado;
            }
            else if(d.NombreUsuario == "Gustavo" && d.Contrasena == "Gustavo")
            {
                return EstadoUsuario.UsuarioAutenticado;
            }
            else
            {
                return EstadoUsuario.UsuariuoNoAutenticado;
            }
        }
    }
}