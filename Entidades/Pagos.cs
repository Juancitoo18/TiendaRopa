using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pagos
    {
        private int _idPago;
        private int _idVenta;
        private int _metodoPago;
        private string _estado;
        private DateTime _fechaPago;
        private decimal _totalPagado;
        Pagos() { }
        public int IdPago { get => _idPago; set => _idPago = value; }
        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int MetodoPago { get => _metodoPago; set => _metodoPago = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime FechaPago { get => _fechaPago; set => _fechaPago = value; }
        public decimal TotalPagado { get => _totalPagado; set => _totalPagado = value; }
    }
}
