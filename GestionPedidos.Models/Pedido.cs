using System;

namespace GestionPedidos.Model
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public int IdFormaPago { get; set; }
    }
}
