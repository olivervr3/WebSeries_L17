using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Library
{
    public class ENPedido
    {
        //LinPed
        private List<ENLineaPedido> linea_pedidos;

        //Variables
        private int numPedido;
        private ENCesta cesta;
        private int usuario;
        private DateTime fecha;
        private int precioTotal;

        public List<ENLineaPedido> linea_Pedidos
        {
            get { return linea_pedidos; }
            set { linea_pedidos = value; }
        }
        public int numPedidoP
        {
            get { return numPedido; }
            set { numPedido = value; }
        }
        public ENCesta cestaPedido
        {
            get { return cesta; }
            set { cesta = value; }
        }
        public int usuarioPedido
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public DateTime fechaPedido
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public int precioTotalPedido
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }
        public ENPedido()
        {
            this.cesta = null;
            this.usuario = 0;
            
            this.precioTotal = 0;
            this.linea_pedidos = new List<ENLineaPedido>();
        }
        public ENPedido(
            int numPedido,
            ENCesta cesta,
            ENUsuario usuario,
            
            int precioTotal,
            List<ENLineaPedido> linea_pedidos
            )
        {
            this.numPedido = numPedido;
            this.cesta = cesta;
            this.usuario = 0;
            
            this.precioTotal = precioTotal;
            this.linea_pedidos = linea_pedidos;
        }
        public bool readPedidoDeUsuario(ENPedido en)
        {
            CADPedido pedido = new CADPedido();
            if (pedido.readPedidoDeUsuario(en))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool createPedido(ENPedido en)
        {
            CADPedido pedido = new CADPedido();
            if (pedido.createPedido(en))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deletePedido(ENPedido en)
        {
            CADPedido pedido = new CADPedido();
            if (pedido.deletePedido(en))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // -- -- -- --
        public bool readLinPed(ENPedido en)
        {
            CADPedido pedido = new CADPedido();
            if (pedido.readLinPed(en))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}