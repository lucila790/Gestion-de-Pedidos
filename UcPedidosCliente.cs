using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPedidos.Controller;

namespace GestionPedido
{
    public partial class UcPedidosCliente : UserControl
    {
        public UcPedidosCliente()
        {
            InitializeComponent();
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.SelectedItem != null)
            {
                var selectedItem = (KeyValuePair<int, string>)cmbClientes.SelectedItem;
                int idCliente = selectedItem.Key;
                CargarPedidosCliente(idCliente);
            }

        }


        private void UcPedidosCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarPedidosCliente(int idCliente)
        {
            try
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string sql = @"SELECT dp.IdDetalle, p.IdPedido, pr.Nombre AS NombreProducto, dp.Cantidad, dp.Subtotal
                           FROM DetallePedidos dp
                           INNER JOIN Pedidos p ON dp.IdPedido = p.IdPedido
                           INNER JOIN Productos pr ON dp.IdProducto = pr.IdProducto
                           WHERE p.IdCliente = @idCliente";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvPedidos.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pedidos: " + ex.Message);
            }
        }




        private void CargarClientes()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "SELECT IdCliente, Nombre FROM Clientes";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Dictionary<int, string> clientes = new Dictionary<int, string>();
                        while (reader.Read())
                        {
                            int id = (int)reader["IdCliente"];
                            string nombre = reader["Nombre"].ToString();
                            clientes.Add(id, nombre);
                        }

                        cmbClientes.DataSource = new BindingSource(clientes, null);
                        cmbClientes.DisplayMember = "Value"; // lo que se muestra
                        cmbClientes.ValueMember = "Key";     // el valor real (IdCliente)
                    }
                }
            }
        }

    }
}
