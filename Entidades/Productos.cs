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
        private int _idCategoriaProducto;
        private int _idTemporadaProducto;
        private string _imagenProducto;
        private bool _estado;
        Productos() { }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public string NombreProducto { get => _nombreProducto; set => _nombreProducto = value; }
        public string DescripcionProducto { get => _descripcionProducto; set => _descripcionProducto = value; }
        public decimal PrecioProducto { get => _precioProducto; set => _precioProducto = value; }
        public int StockProducto { get => _stockProducto; set => _stockProducto = value; }
        public int IdCategoriaProducto { get => _idCategoriaProducto; set => _idCategoriaProducto = value; }
        public int IdTemporadaProducto { get => _idTemporadaProducto; set => _idTemporadaProducto = value; }
        public string ImagenProducto { get => _imagenProducto; set => _imagenProducto = value; }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}
