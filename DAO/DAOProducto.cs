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
    public class DAOProducto
    {
        public List<Productos> Listar()
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    string Query = "SELECT p.id_producto, p.nombre_producto, p.descripcion_producto, p.precio_producto, p.stock_producto,c.id_categoria AS id_categoria_producto, " +
                        "c.nombre_categoria, t.id_Temporada AS id_temporada_producto, t.nombre_Temporada, p.imagen_producto, p.URL_Imagen, p.Estado " +
                        "FROM Productos p INNER JOIN categorias c ON c.id_categoria = p.id_categoria_producto " +
                        "INNER JOIN Temporadas t ON t.id_Temporada = p.id_temporada_producto";

                    SqlCommand cmd = new SqlCommand(Query, cn);
                    cmd.CommandType = CommandType.Text;

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Productos()
                                {
                                    IdProducto = Convert.ToInt32(dr["id_producto"]),
                                    NombreProducto = dr["nombre_producto"].ToString(),
                                    DescripcionProducto = dr["descripcion_producto"].ToString(),
                                    PrecioProducto = Convert.ToDecimal(dr["precio_producto"]),
                                    StockProducto = Convert.ToInt32(dr["stock_producto"]),
                                    objCategoria = new Categorias() { Id = Convert.ToInt32(dr["id_categoria_producto"]), Nombre  = dr["nombre_categoria"].ToString()},
                                    objTemporada = new Temporada() { Id_Temporada = Convert.ToInt32(dr["id_temporada_producto"]), Nombre  = dr["nombre_Temporada"].ToString()},
                                    ImagenProducto = dr["imagen_producto"].ToString(),
                                    URL_Img = dr["URL_Imagen"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Productos>();
            }

            return lista;
        }

        public int Registrar(Productos obj, out string Mensaje)
        {
            int idAutogenerado = 0;
            Mensaje = string.Empty;
            try
            {

                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarProducto", cn);
                    cmd.Parameters.AddWithValue("nombre_producto", obj.NombreProducto);
                    cmd.Parameters.AddWithValue("descripcion_producto", obj.DescripcionProducto);
                    cmd.Parameters.AddWithValue("precio_producto", obj.PrecioProducto);
                    cmd.Parameters.AddWithValue("stock_producto", obj.StockProducto);
                    cmd.Parameters.AddWithValue("id_categoria_producto", obj.objCategoria.Id);
                    cmd.Parameters.AddWithValue("id_temporada_producto", obj.objTemporada.Id_Temporada);
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


        public bool Editar(Productos obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarProducto", cn);
                    cmd.Parameters.AddWithValue("id_producto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("nombre_producto", obj.NombreProducto);
                    cmd.Parameters.AddWithValue("descripcion_producto", obj.DescripcionProducto);
                    cmd.Parameters.AddWithValue("precio_producto", obj.PrecioProducto);
                    cmd.Parameters.AddWithValue("stock_producto", obj.StockProducto);
                    cmd.Parameters.AddWithValue("id_categoria_producto", obj.objCategoria.Id);
                    cmd.Parameters.AddWithValue("id_temporada_producto", obj.objTemporada.Id_Temporada);
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

        public bool GuardarDatosImagen(Productos obj, out string Mensaje)
        {
            bool Resultado = false;
            Mensaje = string.Empty;

            try
            {

                using (SqlConnection cn = new SqlConnection(Conexion.ruta))
                {
                    string Query = "UPDATE Productos SET URL_Imagen = @URLimg, imagen_producto = @ImgProd WHERE id_producto = @idproducto";
                    SqlCommand cmd = new SqlCommand(Query, cn);
                    cmd.Parameters.AddWithValue("URLimg", obj.URL_Img);
                    cmd.Parameters.AddWithValue("ImgProd", obj.ImagenProducto);
                    cmd.Parameters.AddWithValue("idproducto", obj.IdProducto);
                    cmd.CommandType = CommandType.Text;

                    cn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        Resultado = true;
                    }else
                    {
                        Mensaje = "No se Pudo Actualizar la imagen";
                    }

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
                    SqlCommand cmd = new SqlCommand("sp_EliminarProducto", cn);
                    cmd.Parameters.AddWithValue("id_producto ", id);
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
