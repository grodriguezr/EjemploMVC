using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploMVC.Models;
using System.Web.Security;

namespace EjemploMVC.Controllers
{
    public class AutenticacionController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logear(DetallesUsuario d)
        {
            EmpleadoBusinessLayer ebl = new EmpleadoBusinessLayer();
            if (ebl.UsuarioEsValido(d))
            {
                FormsAuthentication.SetAuthCookie(d.NombreUsuario, false);
                return RedirectToAction("Index", "Empleado");
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Nombre o contraseña inválido");
                return View("Login");
            }
        }
    }
}