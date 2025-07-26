using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int _idUsuario;
        private string _nombreUsuario;
        private string _emailUsuario;
        private string _contrasenaUsuario;
        private string _Restablecer;
        private string _rolUsuario;
        private bool _estado;
        public Usuario() { }

        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string EmailUsuario { get => _emailUsuario; set => _emailUsuario = value; }
        public string ContrasenaUsuario { get => _contrasenaUsuario; set => _contrasenaUsuario = value; }
        public string Restablecer { get => _Restablecer; set => _Restablecer = value; }
        public string RolUsuario { get => _rolUsuario; set => _rolUsuario = value; }
        public bool Estado { get => _estado; set => _estado = value; }
    }
    

    
}
