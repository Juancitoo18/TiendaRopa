using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
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
        public JsonResult ListaReporte(string fechainicio, string fechafin, int? idventa)
        {
            try
            {
                var lista = new NegocioReporte().Ventas(fechainicio, fechafin, idventa ?? 0);
                return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<Reporte>(), error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]

        public JsonResult ListaDashboard()
        {
            Dashboard obj = new NegocioReporte().VerDashboard();

            return Json(new { resultado = obj }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public FileResult ExportarVenta(string fechainicio, string fechafin, int? idventa)
        {
            List<Reporte> olista = new List<Reporte>();
            olista = new NegocioReporte().Ventas(fechainicio, fechafin, idventa ?? 0);

            DataTable dt = new DataTable();

            dt.Locale = new System.Globalization.CultureInfo("es-AR");
            dt.Columns.Add("Id Venta", typeof(int));
            dt.Columns.Add("Fecha Venta", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Total", typeof(decimal));

            foreach (Reporte rp in olista)
            {
                dt.Rows.Add(new object[]{
                    rp.IdVenta,
                    rp.FechaVenta,
                    rp.Cliente,
                    rp.Producto,
                    rp.Precio,
                    rp.Cantidad,
                    rp.Total
                });
            }

            dt.TableName = "Datos";

            using(XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using(MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreasheetml.sheet", "ReporteVenta" + DateTime.Now.ToString() + ".xlsx");

                }
            }
        }



    }
}
