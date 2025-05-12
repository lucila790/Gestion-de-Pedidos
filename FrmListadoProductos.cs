using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GestionPedidos.Controller;
using GestionPedidos.Model;

namespace GestionPedido
{
    public partial class FrmListadoProductos : Form
    {
        ProductoController productoController = new ProductoController();
        Producto productoSeleccionado = null;

        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void FrmListadoProductos_Load(object sender, EventArgs e)
        {
            btnBuscar.PerformClick(); // Carga la lista al abrir
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtroNombre = txtFiltroNombre.Text.Trim();
            List<Producto> lista = productoController.ObtenerProductos(filtroNombre);
            dgvProductos.DataSource = lista;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos(); // Formulario vacío para nuevo producto
            frm.ShowDialog();
            btnBuscar.PerformClick(); // Refrescar lista
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista");
                return;
            }

            productoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            FrmProductos frm = new FrmProductos(productoSeleccionado);
            frm.ShowDialog();
            btnBuscar.PerformClick(); // Refrescar lista
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto de la lista");
                return;
            }

            productoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                productoController.EliminarProducto(productoSeleccionado.IdProducto);
                MessageBox.Show("Producto eliminado");
                btnBuscar.PerformClick(); // Refrescar lista
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                productoSeleccionado = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                FrmProductos frm = new FrmProductos(productoSeleccionado);
                frm.ShowDialog();
                btnBuscar.PerformClick(); // Refrescar lista después de modificar
            }
        }
    }
}
