using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENLineaPedido
    {
        private ENPedido pedido;
        private ENCesta cesta;
        private ENSerie serie;
        private String tipoCompra;
        private int precio;

        public ENPedido Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }
        public ENCesta Cesta
        {
            get { return cesta; }
            set { cesta = value; }
        }
        public ENSerie Serie
        {
            get { return serie; }
            set { serie = value; }
        }
        public String TipoCompra
        {
            get { return tipoCompra; }
            set { tipoCompra = value; }
        }
        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public ENLineaPedido ()
        {
        }

        public ENLineaPedido (ENPedido pedido, ENCesta cesta, ENSerie serie, string tipoCompra, int precio)
        {
            this.pedido = pedido;
            this.cesta = cesta;
            this.serie = serie;
            this.tipoCompra = tipoCompra;
            this.precio = precio;
        }
        // Obtener la linea pedido
        public bool readLineaPedido (ENLineaPedido en)
        {
            CADLineaPedido cad = new CADLineaPedido();
            return cad.readLineaPedido(en);
        }
        // Agregar a linea pedido
        public bool createLineaPedido (ENLineaPedido en)
        {
            CADLineaPedido cad = new CADLineaPedido();
            return cad.createLineaPedido(en);
        }
        // Eliminar de linea pedido
        public bool deleteLineaPedido (ENLineaPedido en)
        {
            CADLineaPedido cad = new CADLineaPedido();
            return cad.deleteLineaPedido(en);
        }
        // Elimina todas las lineas de pedido
        public bool deleteAllLineaPedido (ENLineaPedido en)
        {
            CADLineaPedido cad = new CADLineaPedido();
            return cad.deleteAllLineaPedido(en);
        }
    }
}
