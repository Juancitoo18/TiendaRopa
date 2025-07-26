using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;

namespace Negocio
{
    public class NegocioUsuario
    {
        private DAOUsuarios DaoUsu = new DAOUsuarios();
        
        public List<Usuario> Listar()
        {
            return DaoUsu.Listar();
        }

        public int Registrar(Usuario Usu, out string Mensaje)
        {
            Mensaje = string.Empty;
            if(string.IsNullOrEmpty(Usu.NombreUsuario) || string.IsNullOrWhiteSpace(Usu.NombreUsuario))
            {
                Mensaje = "El Nombre del Usuario no puede ser vacio";
            } else if (string.IsNullOrEmpty(Usu.EmailUsuario) || string.IsNullOrWhiteSpace(Usu.EmailUsuario))
            {
                Mensaje = "El Correo no puede ser vacio";
            }
      

            if (string.IsNullOrEmpty(Mensaje))
            {
                Usu.ContrasenaUsuario = "123456";
                Usu.Restablecer = "123456";
                Usu.RolUsuario = "cliente";
                return DaoUsu.Registrar(Usu, out Mensaje);
            }
            else
            {
                return 0;
            }

            
        }

        public bool Editar(Usuario Usu, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(Usu.NombreUsuario) || string.IsNullOrWhiteSpace(Usu.NombreUsuario))
            {
                Mensaje = "El Nombre del Usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(Usu.EmailUsuario) || string.IsNullOrWhiteSpace(Usu.EmailUsuario))
            {
                Mensaje = "El Correo no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return DaoUsu.Editar(Usu, out Mensaje);
            }
            else
            {
                return false;
            }
            
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return DaoUsu.Eliminar(id, out Mensaje);
        }

    }
}
