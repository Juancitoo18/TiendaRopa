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
    
   public class DAOCategoria
   {
        public List<Categorias> Listar()
        {
            List<Categorias> lista = new List<Categorias>();

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    string Query = "select * from categorias";

                    SqlCommand cmd = new SqlCommand(Query, cn);
                    cmd.CommandType = CommandType.Text;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Categorias()
                                {
                                    Id = Convert.ToInt32(dr["id_categoria"]),
                                    Nombre = dr["nombre_categoria"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Categorias>();
            }

            return lista;
        }

        public int Registrar(Categorias cate, out string Mensaje)
        {
            int idAutogenerado = 0;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarCategoria", cn);
                    cmd.Parameters.AddWithValue("Nombre", cate.Nombre);
                    cmd.Parameters.AddWithValue("Estado", cate.Estado);
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

        public bool Editar(Categorias cate, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarCategoria", cn);
                    cmd.Parameters.AddWithValue("ID", cate.Id);
                    cmd.Parameters.AddWithValue("Nombre", cate.Nombre);
                    cmd.Parameters.AddWithValue("Estado", cate.Estado);
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
                    SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", cn);
                    cmd.Parameters.AddWithValue("IDCategoria ", id);
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
