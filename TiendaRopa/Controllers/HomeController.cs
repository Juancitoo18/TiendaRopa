using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace TiendaRopa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuario()
        {
            List<Usuario> Lista = new List<Usuario>();

            Lista = new NegocioUsuario().Listar();

            return Json(new {data = Lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuario Usu)
        {
            object resultado;
            string Mensaje = string.Empty;
            if (Usu.IdUsuario == 0)
            {
                resultado = new NegocioUsuario().Registrar(Usu, out Mensaje);
            }
            else
            {
                resultado = new NegocioUsuario().Editar(Usu, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new NegocioUsuario().Eliminar(id, out Mensaje);

            return Json(new { resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]

        public JsonResult ListaReporte(string fechainicio, string fechafin, int idventa)
        {

            List<Reporte> lista = new List<Reporte>();

            lista = new NegocioReporte().Ventas(fechainicio,fechafin,idventa);

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]

        public JsonResult ListaDashboard()
        {
            Dashboard obj = new NegocioReporte().VerDashboard();

            return Json(new { resultado = obj }, JsonRequestBehavior.AllowGet);
        }



    }
}
