using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;

namespace Negocio
{
    public class NegocioProducto
    {
        private DAOProducto DaoProd = new DAOProducto();

        public List<Productos> Listar()
        {
            return DaoProd.Listar();
        }

        public int Registrar(Productos obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.NombreProducto) || string.IsNullOrWhiteSpace(obj.NombreProducto))
            {
                Mensaje = "El Nombre del Producto no puede ser vacia";
            }
            else if (string.IsNullOrEmpty(obj.DescripcionProducto) || string.IsNullOrWhiteSpace(obj.DescripcionProducto))
            {
                Mensaje = "La Descripcion del Producto no puede ser vacia";
            }
            else if (obj.PrecioProducto == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }
            else if (obj.StockProducto == 0)
            {
                Mensaje = "Debe ingresar el stock del producto";
            }
            else if (obj.objCategoria.Id == 0) 
            {
                Mensaje = "Debe Seleccionar una Categoria";
            }
            else if (obj.objTemporada.Id_Temporada == 0)
            {
                Mensaje = "Debe Seleccionar una Temporada";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return DaoProd.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }

        public bool Editar(Productos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreProducto) || string.IsNullOrWhiteSpace(obj.NombreProducto))
            {
                Mensaje = "El Nombre del Producto no puede ser vacia";
            }
            else if (string.IsNullOrEmpty(obj.DescripcionProducto) || string.IsNullOrWhiteSpace(obj.DescripcionProducto))
            {
                Mensaje = "La Descripcion del Producto no puede ser vacia";
            }
            else if (obj.PrecioProducto == 0)
            {
                Mensaje = "Debe ingresar el precio del producto";
            }
            else if (obj.StockProducto == 0)
            {
                Mensaje = "Debe ingresar el stock del producto";
            }
            else if (obj.objCategoria.Id == 0)
            {
                Mensaje = "Debe Seleccionar una Categoria";
            }
            else if (obj.objTemporada.Id_Temporada == 0)
            {
                Mensaje = "Debe Seleccionar una Temporada";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return DaoProd.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }

        }

        public bool GuardarDatosImagen(Productos obj, out string Mensaje)
        {
            return DaoProd.GuardarDatosImagen(obj, out Mensaje);
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return DaoProd.Eliminar(id, out Mensaje);
        }
    }
}
