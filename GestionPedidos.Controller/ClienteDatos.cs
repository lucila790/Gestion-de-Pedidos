using GestionPedidos.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionPedidos.Controller
{
    public class ClienteDatos
    {
        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string consulta = "SELECT * FROM Clientes";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cliente cli = new Cliente
                    {
                        IdCliente = (int)dr["IdCliente"],
                        Nombre = dr["Nombre"].ToString(),
                        Email = dr["Email"].ToString(),
                        Telefono = dr["Telefono"].ToString()
                    };
                    lista.Add(cli);
                }
            }
            return lista;
        }

        public List<Cliente> ObtenerPorNombre(string nombre)
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string consulta = "SELECT * FROM Clientes WHERE Nombre LIKE @nombre";
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cliente cli = new Cliente
                    {
                        IdCliente = (int)dr["IdCliente"],
                        Nombre = dr["Nombre"].ToString(),
                        Email = dr["Email"].ToString(),
                        Telefono = dr["Telefono"].ToString()
                    };
                    lista.Add(cli);
                }
            }
            return lista;
        }
    }
}
