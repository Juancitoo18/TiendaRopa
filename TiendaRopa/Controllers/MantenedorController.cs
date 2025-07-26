using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace TiendaRopa.Controllers
{
    public class MantenedorController : Controller
    {
        public ActionResult Categoria()
        {
            return View();
        }

        public ActionResult Producto()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarCategoria()
        {
            List<Categorias> Lista = new List<Categorias>();

            Lista = new NegocioCategoria().Listar();

            return Json(new { data = Lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarCategoria(Categorias Cate)
        {
            object resultado;
            string Mensaje = string.Empty;
            if (Cate.Id == 0)
            {
                resultado = new NegocioCategoria().Registrar(Cate, out Mensaje);
            }
            else
            {
                resultado = new NegocioCategoria().Editar(Cate, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new NegocioCategoria().Eliminar(id, out Mensaje);

            return Json(new { resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}