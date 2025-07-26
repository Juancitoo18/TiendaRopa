using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        private int _idVenta;
        private int _idClienteVt;
        private DateTime _fechaVt;
        private int _metodoEnvio;
        private decimal _totalVt;
        private bool _estado;
        Venta() { }
        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int IdClienteVt { get => _idClienteVt; set => _idClienteVt = value; }
        public DateTime FechaVt { get => _fechaVt; set => _fechaVt = value; }
        public int MetodoEnvio { get => _metodoEnvio; set => _metodoEnvio = value; }
        public decimal TotalVt { get => _totalVt; set => _totalVt = value; }
        public bool Estado { get => _estado; set => _estado = value; }
    }
}
