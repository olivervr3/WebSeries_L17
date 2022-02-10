using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class ENLineaCesta
    {
        private ENCesta cesta;
        private ENSerie serie;
        private String tipoCompra;
        private double precio;

        public ENLineaCesta() 
        {         
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

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public ENLineaCesta(ENCesta cesta, ENSerie serie, string tipoCompra, int precio) 
        {
            this.cesta = cesta;
            this.serie = serie;
            this.tipoCompra = tipoCompra;
            this.precio = precio;
        }

        /// <summary>
        /// Añadir una linea a una cesta
        /// </summary>
        /// <param name="en">La cesta y la linea a añadir</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool AgregarALineaCesta(ENLineaCesta en)
        {
            CADLineaCesta cad = new CADLineaCesta();
            return cad.AgregarALineaCesta(en);
        }

        /// <summary>
        /// Eliminar una linea de la cesta
        /// </summary>
        /// <param name="en">La línea y la cesta a eliminar de mis series</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool EliminarDeLineaCesta(ENLineaCesta en)
        {
            CADLineaCesta cad = new CADLineaCesta();
            return cad.EliminarDeLineaCesta(en);
        }

        /// <summary>
        /// Obtener las líneas series de una cesta
        /// </summary>
        /// <param name="en">La cesta de la que extraer las líneas</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool ObtenerLineaCesta(ENLineaCesta en)
        {
            CADLineaCesta cad = new CADLineaCesta();
            return cad.ObtenerLineaCesta(en);
        }

        /// <summary>
        /// Actualizar la lista de líneas de un cesta
        /// </summary>
        /// <param name="en">La cesta y la lista de lineas a actualizar</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool ActualizarMisSeries(ENLineaCesta en)
        {
            CADLineaCesta cad = new CADLineaCesta();
            return cad.ActualizarLineaCesta(en);
        }

        /// <summary>
        /// Se eliminarán todas las líneas de una cesta
        /// </summary>
        /// <param name="en">La cesta a la que se le quieren eliminar todas sus mis líneas</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool EliminarTodasLineaCesta(ENLineaCesta en)
        {
            CADLineaCesta cad = new CADLineaCesta();
            return cad.EliminarTodasLineaCesta(en);
        }

        /// <summary>
        /// Comprobar si una serie esta en una cesta o en mis series
        /// </summary>
        /// <param name="numCesta">Id de la cesta</param>
        /// <param name="nombreSerie">Nombre de la serie</param>
        /// <param name="emailUsuario">Email del usuario opcional</param>
        /// <returns></returns>
        public bool ExisteSerieEnCestaOMisSeries(int numCesta, string nombreSerie, string emailUsuario)
        {
            CADLineaCesta cad = new CADLineaCesta();
            return cad.ExisteSerieEnCestaOMisSeries(numCesta, nombreSerie, emailUsuario);
        }
    }

}
