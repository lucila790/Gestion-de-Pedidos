using System.Collections.Generic;
using System.Data.SqlClient;
using GestionPedidos.Model;

namespace GestionPedidos.Controller
{
    public class ProductoController
    {
        public List<Producto> ObtenerProductos(string filtroNombre = "")
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "SELECT * FROM Productos";
                if (!string.IsNullOrEmpty(filtroNombre))
                {
                    sql += " WHERE Nombre LIKE @filtro";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(filtroNombre))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtroNombre + "%");
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                IdProducto = (int)reader["IdProducto"],
                                Nombre = reader["Nombre"].ToString(),
                                Precio = (decimal)reader["Precio"],
                                Stock = (int)reader["Stock"]
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public void AgregarProducto(Producto prod)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "INSERT INTO Productos (Nombre, Precio, Stock) VALUES (@nombre, @precio, @stock)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", prod.Nombre);
                    cmd.Parameters.AddWithValue("@precio", prod.Precio);
                    cmd.Parameters.AddWithValue("@stock", prod.Stock);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarProducto(Producto prod)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "UPDATE Productos SET Nombre=@nombre, Precio=@precio, Stock=@stock WHERE IdProducto=@id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", prod.Nombre);
                    cmd.Parameters.AddWithValue("@precio", prod.Precio);
                    cmd.Parameters.AddWithValue("@stock", prod.Stock);
                    cmd.Parameters.AddWithValue("@id", prod.IdProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProducto(int id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "DELETE FROM Productos WHERE IdProducto=@id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
