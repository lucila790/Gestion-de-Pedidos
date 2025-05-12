using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GestionPedidos.Model;
using GestionPedidos.Controller;

namespace GestionPedidos.Controller
{

    public class ClienteController
    {
        private ClienteDatos clienteDatos = new ClienteDatos();
        // Obtener todos los clientes
        public List<Cliente> ObtenerClientes(string filtroNombre)
        {
            if (string.IsNullOrEmpty(filtroNombre))
            {
                return clienteDatos.ObtenerTodos();
            }
            else
            {
                return clienteDatos.ObtenerPorNombre(filtroNombre);
            }
        }



        // Agregar cliente
        public void AgregarCliente(Cliente cliente)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "INSERT INTO Clientes (Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.ExecuteNonQuery();
            }
        }

        // Modificar cliente
        public void ModificarCliente(Cliente cliente)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE Clientes SET Nombre=@Nombre, Email=@Email, Telefono=@Telefono WHERE IdCliente=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Id", cliente.IdCliente);
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar cliente
        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "DELETE FROM Clientes WHERE IdCliente=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", idCliente);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
