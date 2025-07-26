using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        private int _idCli;
        private string _NombreCli;
        private string _ApellidoCli;
        private string _DniCli;
        private string _SexoCli;
        private string _FechaNacimientoCli;
        private string _TelefonoCli;
        private string _DireccionCli;
        private int _idUsuarioCli;
        private int _idProvinciaCli;
        private int _idLocalidadCli;
        private bool _Estado;

        public Clientes() { }

        public int IdCli { get => _idCli; set => _idCli = value; }
        public string NombreCli { get => _NombreCli; set => _NombreCli = value; }
        public string ApellidoCli { get => _ApellidoCli; set => _ApellidoCli = value; }
        public string DniCli { get => _DniCli; set => _DniCli = value; }
        public string SexoCli { get => _SexoCli; set => _SexoCli = value; }
        public string FechaNacimientoCli { get => _FechaNacimientoCli; set => _FechaNacimientoCli = value; }
        public string TelefonoCli { get => _TelefonoCli; set => _TelefonoCli = value; }
        public string DireccionCli { get => _DireccionCli; set => _DireccionCli = value; }
        public int IdUsuarioCli { get => _idUsuarioCli; set => _idUsuarioCli = value; }
        public int IdProvinciaCli { get => _idProvinciaCli; set => _idProvinciaCli = value; }
        public int IdLocalidadCli { get => _idLocalidadCli; set => _idLocalidadCli = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }
    }
}
