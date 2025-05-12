using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionPedidos.Controller;
using GestionPedidos.Model;

namespace GestionPedido
{
    public partial class FrmListadoCLientes : Form

    {
        ClienteController clienteController = new ClienteController();
        Cliente clienteSeleccionado = null;

        public FrmListadoCLientes()
        {
            InitializeComponent();
        }


        private void FrmListadoCLientes_Load(object sender, EventArgs e)
        {
            // Opcional: cargar todos los clientes al abrir el formulario
            btnBuscar.PerformClick();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtroNombre = txtFiltroNombre.Text.Trim();
            List<Cliente> lista = clienteController.ObtenerClientes(filtroNombre);
            dgvClientes.DataSource = lista;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes(); // formulario vacío para nuevo cliente
            frm.ShowDialog();
            btnBuscar.PerformClick(); // refrescar lista
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente de la lista");
                return;
            }

            clienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            FrmClientes frm = new FrmClientes(clienteSeleccionado);
            frm.ShowDialog();
            btnBuscar.PerformClick(); // refrescar lista
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente de la lista");
                return;
            }

            clienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                clienteController.EliminarCliente(clienteSeleccionado.IdCliente);
                MessageBox.Show("Cliente eliminado");
                btnBuscar.PerformClick(); // refrescar lista
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clienteSeleccionado = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                FrmClientes frm = new FrmClientes(clienteSeleccionado);
                frm.ShowDialog();
                btnBuscar.PerformClick(); // refrescar lista después de modificar
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente de la lista");
                return;
            }

            clienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            FrmClientes frm = new FrmClientes(clienteSeleccionado);
            frm.ShowDialog();
            btnBuscar.PerformClick(); // refrescar lista

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente de la lista");
                return;
            }

            Cliente clienteSeleccionado = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                clienteController.EliminarCliente(clienteSeleccionado.IdCliente);
                MessageBox.Show("Cliente eliminado");
                btnBuscar.PerformClick(); // refrescar lista
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
