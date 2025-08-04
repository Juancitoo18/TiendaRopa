using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;

namespace Negocio
{
    public  class NegocioReporte
    {
        private DAOReporte DaoRe = new DAOReporte();

        public Dashboard VerDashboard()
        {
            return DaoRe.VerDashboard();
        }

        public List<Reporte> Ventas(string fechainicio, string fechafin, int idventa)
        {
            return DaoRe.Ventas(fechainicio, fechafin, idventa);
        }
    }


}
