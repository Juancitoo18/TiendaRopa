using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DAOReporte
    {
        public Dashboard VerDashboard()
        {
            Dashboard objeto = new Dashboard();

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteDashboard", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Dashboard()
                            {
                                TotalCliente = Convert.ToInt32(dr["TotalClientes"]),
                                TotalVenta = Convert.ToInt32(dr["TotalVentas"]),
                                TotalProducto = Convert.ToInt32(dr["TotalProductos"]),

                            };
                        }
                    }
                }
            }
            catch
            {
                objeto = new Dashboard();
            }

            return objeto;
        }

        public List<Reporte> Ventas(string fechainicio, string fechafin, int idventa)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {

                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", cn);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.Parameters.AddWithValue("@idVenta", idventa);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(
                                new Reporte()
                                {
                                    IdVenta = Convert.ToInt32(dr["IdVenta"]),
                                    FechaVenta = dr["fecha"].ToString(),
                                    Cliente = dr["Nombre_Clientes"].ToString(),
                                    Producto = dr["PRODUCTO"].ToString(),
                                    Precio = Convert.ToDecimal( dr["Precio"]),
                                    Cantidad = Convert.ToInt32 (dr["Cantidad"]),
                                    Total = Convert.ToDecimal(dr["Total"]),
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }

            return lista;
        }


    }
}
