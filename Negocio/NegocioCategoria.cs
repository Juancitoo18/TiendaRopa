using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;

namespace Negocio
{
    public class NegocioCategoria
    {
        private DAOCategoria DaoCate = new DAOCategoria();

        public List<Categorias> Listar()
        {
            return DaoCate.Listar();
        }

        public int Registrar(Categorias Cate, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(Cate.Nombre) || string.IsNullOrWhiteSpace(Cate.Nombre))
            {
                Mensaje = "El Nombre de la categoria no puede ser vacia";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
               
                return DaoCate.Registrar(Cate, out Mensaje);
            }
            else
            {
                return 0;
            }


        }

        public bool Editar(Categorias Cate, out string Mensaje)
        {
            Mensaje = string.Empty;
            if(string.IsNullOrEmpty(Cate.Nombre) || string.IsNullOrWhiteSpace(Cate.Nombre))
            {
                Mensaje = "El Nombre de la categoria no puede ser vacia";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                return DaoCate.Editar(Cate, out Mensaje);
            }
            else
            {
                return false;
            }

        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return DaoCate.Eliminar(id, out Mensaje);
        }
    }
}
