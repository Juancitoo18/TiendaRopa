using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
namespace DAO
{
    public class Conexion
    {
        public static string ruta = ConfigurationManager.ConnectionStrings["cadena"].ToString();


    }
}
