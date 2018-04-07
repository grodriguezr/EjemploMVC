using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploMVC.Models;
using System.Web.Security;

namespace EjemploMVC.Controllers
{
    [AllowAnonymous]
    public class AutenticacionController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logear(DetallesUsuario d)
        {
            if (ModelState.IsValid)
            {
                EmpleadoBusinessLayer ebl = new EmpleadoBusinessLayer();
                EstadoUsuario estado = ebl.GetUserValidity(d);
                bool esAdmin = false;
                if(estado == EstadoUsuario.AdminAutenticado)
                {
                    esAdmin = true;
                }
                else if(estado == EstadoUsuario.UsuarioAutenticado)
                {
                    esAdmin = false;
                }
                //if (ebl.UsuarioEsValido(d))
                //{
                //    FormsAuthentication.SetAuthCookie(d.NombreUsuario, false);
                //    return RedirectToAction("Index", "Empleado");
                //}
                else
                {
                    ModelState.AddModelError("CredentialError", "Nombre o contraseña inválido");
                    return View("Login");
                }
                FormsAuthentication.SetAuthCookie(d.NombreUsuario, false);
                Session["EsAdmin"] = esAdmin;
                return RedirectToAction("Index", "Empleado");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}