using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Negocio
{
    public class NegocioRecursos
    {
        public static string ConvertirEnBase64(string ruta, out bool conversion)
        {
            string texto = string.Empty;
            conversion = true;

            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);
                texto = Convert.ToBase64String(bytes);
            }
            catch 
            {
                conversion = false;
            }

            return texto;
        }
    }
}
