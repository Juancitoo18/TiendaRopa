using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;
using Newtonsoft.Json;

namespace TiendaRopa.Controllers
{
    public class MantenedorController : Controller
    {
        public ActionResult Categoria()
        {
            return View();
        }

        public ActionResult Temporada()
        {
            return View();
        }

        public ActionResult Producto()
        {
            return View();
        }

        /*Categoria*/
        #region Categoria
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
        #endregion Categoria

        /*Temporada*/

        #region Temporada

        [HttpGet]
        public JsonResult ListarTemporada()
        {
            List<Temporada> Lista = new List<Temporada>();

            Lista = new NegocioTemporada().Listar();

            return Json(new { data = Lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTemporada(Temporada obj)
        {
            object resultado;
            string Mensaje = string.Empty;
            if (obj.Id_Temporada == 0)
            {
                resultado = new NegocioTemporada().Registrar(obj, out Mensaje);
            }
            else
            {
                resultado = new NegocioTemporada().Editar(obj, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTemporada(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new NegocioTemporada().Eliminar(id, out Mensaje);

            return Json(new { resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion Temporada

        /*Producto*/

        #region Producto
        [HttpGet]
        public JsonResult ListarProducto()
        {
            List<Productos> Lista = new List<Productos>();

            Lista = new NegocioProducto().Listar();

            return Json(new { data = Lista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarProducto(string obj, HttpPostedFileBase ArchivoImg )
        {
            string Mensaje = string.Empty;
            bool OPexitosa = true;
            bool GuardarImg = true;

            Productos OProducto = new Productos();
            OProducto = JsonConvert.DeserializeObject<Productos>(obj);

            


            if (OProducto.IdProducto == 0)
            {
                int idGenerado = new NegocioProducto().Registrar(OProducto, out Mensaje);

                if(idGenerado != 0)
                {
                    OProducto.IdProducto = idGenerado;
                }
                else
                {
                    OPexitosa = false;
                }
            }
            else
            {
                OPexitosa = new NegocioProducto().Editar(OProducto, out Mensaje);
            }

            if (OPexitosa)
            {
                if(ArchivoImg != null)
                {
                    string rutaGuardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(ArchivoImg.FileName);
                    string NombreImagen = string.Concat(OProducto.IdProducto.ToString(),extension);

                    try
                    {
                        ArchivoImg.SaveAs(Path.Combine(rutaGuardar, NombreImagen));
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        GuardarImg = false;
                    }


                    if (GuardarImg)
                    {
                        OProducto.URL_Img = rutaGuardar;
                        OProducto.ImagenProducto = NombreImagen;
                        bool rta = new NegocioProducto().GuardarDatosImagen(OProducto, out Mensaje);
                    }
                    else
                    {
                        Mensaje = "se guardo el producto pero hubo problemas con la imagen";
                    }
                }
            }


            return Json(new { OPexitosa = OPexitosa, idGenerado= OProducto.IdProducto, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ImagenProducto(int id)
        {
            bool conversion;
            Productos obj = new NegocioProducto().Listar().Where(p => p.IdProducto == id).FirstOrDefault();

            string TextoBase64 = NegocioRecursos.ConvertirEnBase64(Path.Combine(obj.URL_Img, obj.ImagenProducto), out conversion);

            return Json(new
            {
                conversion = conversion,
                TextoBase64 = TextoBase64,
                extension = Path.GetExtension(obj.ImagenProducto)
            },
                JsonRequestBehavior.AllowGet
            );
        }


       [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool Respuesta = false;
            string Mensaje = string.Empty;

            Respuesta = new NegocioProducto().Eliminar(id, out Mensaje);

            return Json(new { resultado = Respuesta, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion Producto
    }
}