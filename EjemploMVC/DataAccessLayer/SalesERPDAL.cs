using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EjemploMVC.Models;

namespace EjemploMVC.DataAccessLayer
{
    public class SalesERPDAL : DbContext
    {
        public DbSet<Empleado> empleados { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().ToTable("TblEmpleado");
            base.OnModelCreating(modelBuilder);
        }
    }
}