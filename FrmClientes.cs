using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionPedidos.Controller;
using GestionPedidos.Model;



namespace GestionPedido

{
    public partial class FrmClientes : Form
    {
        ClienteController clienteController = new ClienteController();
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }

    
    Cliente clienteActual;

        public FrmClientes(Cliente cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (clienteActual != null)
            {
                txtNombre.Text = clienteActual.Nombre;
                txtEmail.Text = clienteActual.Email;
                txtTelefono.Text = clienteActual.Telefono;
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            Cliente nuevo = new Cliente
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text
            };

            clienteController.AgregarCliente(nuevo);
            MessageBox.Show("Cliente agregado");
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (clienteActual == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para modificar");
                return;
            }

            clienteActual.Nombre = txtNombre.Text;
            clienteActual.Email = txtEmail.Text;
            clienteActual.Telefono = txtTelefono.Text;

            clienteController.ModificarCliente(clienteActual);
            MessageBox.Show("Cliente modificado");
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteActual == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para eliminar");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                clienteController.EliminarCliente(clienteActual.IdCliente);
                MessageBox.Show("Cliente eliminado");
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            clienteActual = null;
        }
    }

}
