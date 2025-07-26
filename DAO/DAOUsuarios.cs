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
    public class DAOUsuarios
    {

        public List<Usuario> Listar(){
            List<Usuario> lista = new List<Usuario>();

            try{
                using (SqlConnection cn = new SqlConnection(Conexion.ruta)){
                    string Query = "select * from usuarios";

                    SqlCommand cmd = new SqlCommand(Query,cn);
                    cmd.CommandType = CommandType.Text;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()){
                        while (dr.Read()){

                            lista.Add(
                                new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["id_usuario"]),
                                    NombreUsuario = dr["nombre_usuario"].ToString(),
                                    EmailUsuario = dr["email_usuario"].ToString(),
                                    ContrasenaUsuario = dr["contraseña_usuario"].ToString(),
                                    Restablecer = dr["restablecer_usuario"].ToString(),
                                    RolUsuario = dr["rol_usuario"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                }
                                ); 
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Usuario>();
            }

            return lista;
        }

        public int Registrar(Usuario Usu, out string Mensaje)
        {
            int idAutogenerado = 0;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarUsuario", cn);
                    cmd.Parameters.AddWithValue("Nombre", Usu.NombreUsuario);
                    cmd.Parameters.AddWithValue("Correo", Usu.EmailUsuario);
                    cmd.Parameters.AddWithValue("Clave", Usu.ContrasenaUsuario);
                    cmd.Parameters.AddWithValue("Restablecer", Usu.Restablecer);
                    cmd.Parameters.AddWithValue("Rol", Usu.RolUsuario);
                    cmd.Parameters.AddWithValue("Estado", Usu.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    cmd.ExecuteNonQuery();

                    idAutogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                idAutogenerado = 0;
                Mensaje = ex.Message;
            }

            return idAutogenerado;
        }

        public bool Editar(Usuario Usu, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuario", cn);
                    cmd.Parameters.AddWithValue("ID", Usu.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombre", Usu.NombreUsuario);
                    cmd.Parameters.AddWithValue("Correo", Usu.EmailUsuario);
                    cmd.Parameters.AddWithValue("Estado", Usu.Estado);
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
                    SqlCommand cmd = new SqlCommand("delete top (1)  from usuarios where id_usuario = @id", cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    Resultado = cmd.ExecuteNonQuery() > 0 ? true : false;

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
