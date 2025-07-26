using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad
    {
        private int _id;
        private int _idProvincia;
        private string _Nombre;

        private bool _Estado;

        public Localidad() { }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }
        public int IdProvincia { get => _idProvincia; set => _idProvincia = value; }
    }
}

