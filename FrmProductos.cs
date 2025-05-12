using System;
using System.Windows.Forms;
using GestionPedidos.Controller;
using GestionPedidos.Model;

namespace GestionPedido
{
    public partial class FrmProductos : Form
    {
        ProductoController productoController = new ProductoController();
        Producto productoActual = null;

        // Constructor vacío (para agregar)
        public FrmProductos()
        {
            InitializeComponent();
        }

        // Constructor con producto (para modificar)
        public FrmProductos(Producto prod) : this()
        {
            productoActual = prod;
            txtNombre.Text = prod.Nombre;
            txtPrecio.Text = prod.Precio.ToString();
            txtStock.Text = prod.Stock.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            Producto nuevoProducto = new Producto()
            {
                Nombre = txtNombre.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text)
            };

            if (productoActual == null)
            {
                productoController.AgregarProducto(nuevoProducto);
                MessageBox.Show("Producto agregado");
            }
            else
            {
                nuevoProducto.IdProducto = productoActual.IdProducto;
                productoController.ModificarProducto(nuevoProducto);
                MessageBox.Show("Producto modificado");
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
