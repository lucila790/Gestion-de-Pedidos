using System.Data.SqlClient;

namespace GestionPedidos.Controller
{
    public static class Conexion
    {
        // Cambiá el nombre del servidor si es necesario (localhost, .\SQLEXPRESS, etc.)
        private static string cadenaConexion = "Server=localhost;Database=GestionPedidos;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
