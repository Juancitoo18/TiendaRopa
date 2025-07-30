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
    public class DAOTemporada
    {
        public List<Temporada> Listar()
        {
            List<Temporada> lista = new List<Temporada>();

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    string Query = "select * from Temporadas";

                    SqlCommand cmd = new SqlCommand(Query, cn);
                    cmd.CommandType = CommandType.Text;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Temporada()
                                {
                                    Id_Temporada = Convert.ToInt32(dr["id_Temporada"]),
                                    Nombre = dr["nombre_Temporada"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Temporada>();
            }

            return lista;
        }

        public int Registrar(Temporada obj, out string Mensaje)
        {
            int idAutogenerado = 0;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarTemporada", cn);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    cmd.ExecuteNonQuery();

                    idAutogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idAutogenerado = 0;
                Mensaje = ex.Message;
            }

            return idAutogenerado;
        }

        public bool Editar(Temporada obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarTemporada", cn);
                    cmd.Parameters.AddWithValue("ID", obj.Id_Temporada);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }

            return Resultado;

        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarTemporada", cn);
                    cmd.Parameters.AddWithValue("IDTemporada ", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    cmd.ExecuteNonQuery();

                    Resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                Mensaje = ex.Message;
            }

            return Resultado;

        }
    }
}
