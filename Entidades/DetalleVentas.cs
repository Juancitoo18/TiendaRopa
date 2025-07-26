using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVentas
    {
        private int _idDetalle;
        private int _idVentaDt;
        private int _idProductoDt;
        private int _cantidadDt;
        private decimal _precioUnitarioDt;
        private decimal _subtotalDt;
        private bool _estado;
        DetalleVentas() { }
        public int IdDetalle { get => _idDetalle; set => _idDetalle = value; }
        public int IdVentaDt { get => _idVentaDt; set => _idVentaDt = value; }
        public int IdProductoDt { get => _idProductoDt; set => _idProductoDt = value; }
        public int CantidadDt { get => _cantidadDt; set => _cantidadDt = value; }
        public decimal PrecioUnitarioDt { get => _precioUnitarioDt; set => _precioUnitarioDt = value; }
        public decimal SubtotalDt { get => _subtotalDt; set => _subtotalDt = value; }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}
