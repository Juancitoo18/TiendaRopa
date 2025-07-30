using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        private int _idProducto;
        private string _nombreProducto;
        private string _descripcionProducto;
        private decimal _precioProducto;
        private int _stockProducto;
        private Categorias _objCategoria;
        private Temporada _objTemporada;
        private string _imagenProducto;
        private string _URL_Imagen;
        private bool _estado;
        public Productos() { }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string NombreProducto { get => _nombreProducto; set => _nombreProducto = value; }
        public string DescripcionProducto { get => _descripcionProducto; set => _descripcionProducto = value; }
        public decimal PrecioProducto { get => _precioProducto; set => _precioProducto = value; }
        public int StockProducto { get => _stockProducto; set => _stockProducto = value; }
        public Categorias objCategoria { get => _objCategoria; set => _objCategoria = value; }
        public Temporada objTemporada { get => _objTemporada; set => _objTemporada = value; }
        public string ImagenProducto { get => _imagenProducto; set => _imagenProducto = value; }
        public string URL_Img { get => _URL_Imagen; set => _URL_Imagen = value; }
        public bool Estado { get => _estado; set => _estado = value; }
        public string Base64{ get; set; }
        public string Extesion{ get; set; }

    }
}
