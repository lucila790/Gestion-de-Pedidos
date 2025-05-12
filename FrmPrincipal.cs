using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPedido
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listadoClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoCLientes frm = new FrmListadoCLientes();
            frm.ShowDialog();
        }

        private void aMBClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoCLientes frm = new FrmListadoCLientes();
            frm.ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Limpiar el panel por si hay algo cargado antes
            panelContenedor.Controls.Clear();

            // Crear instancia del UserControl
            UcPedidosCliente uc = new UcPedidosCliente();

            // Ajustarlo al panel
            uc.Dock = DockStyle.Fill;

            // Agregarlo al panel
            panelContenedor.Controls.Add(uc);
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListadoProductos frm = new FrmListadoProductos();
            frm.ShowDialog();  
        }
    }
}
