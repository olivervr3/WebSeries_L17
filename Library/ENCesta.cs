using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENCesta
    {
        private int numCesta;
        private ENUsuario usuario;
        private List<ENLineaCesta> lineas;

        public int NumCesta
        {
            get { return numCesta; }
            set { numCesta = value; }
        }

        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public List<ENLineaCesta> Lineas
        {
            get { return lineas; }
            set { lineas = value; }
        }

        public ENCesta()
        {
            this.usuario = null;
            this.lineas = new List<ENLineaCesta>();
        }

        public ENCesta(int numCesta, ENUsuario usuario, List<ENLineaCesta> lineas)
        {
            this.numCesta = numCesta;
            this.usuario = usuario;
            this.lineas = lineas;
        }

        /// <summary>
        /// Crear una nueva cesta de la compra de series
        /// </summary>
        /// <param name="en">La cesta y sus datos necesarios</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool CrearCesta(ENCesta en) {
            CADCesta cad = new CADCesta();
            return cad.CrearCesta(en);
        }

        /// <summary>
        /// Eliminar una cesta de la compra existente
        /// </summary>
        /// <param name="en">La cesta y sus datos necesarios</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool EliminarCesta(ENCesta en)
        {
            CADCesta cad = new CADCesta();
            return cad.EliminarCesta(en);
        }

        /// <summary>
        /// Actualizar los datos de una cesta
        /// </summary>
        /// <param name="en">La cesta y sus datos a actualizar</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool ActualizarCesta(ENCesta en)
        {
            CADCesta cad = new CADCesta();
            return cad.ActualizarCesta(en);
        }

        /// <summary>
        /// Obtener los datos de una cesta
        /// </summary>
        /// <param name="en">La cesta de la que se quieren obtener los datos</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool ObtenerCesta(ENCesta en)
        {
            CADCesta cad = new CADCesta();
            return cad.ObtenerCesta(en);
        }

        /// <summary>
        /// Obtener la cesta asociada a un usuario
        /// </summary>
        /// <param name="en">El usuario para el que se desea obtener su cesta</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool ObtenerCestaDeUsuario(ENCesta en)
        {
            CADCesta cad = new CADCesta();
            return cad.ObtenerCestaDeUsuario(en);
        }

        public bool ObtenerLineasCesta(ENCesta en)
        {
            CADCesta cad = new CADCesta();
            return cad.ObtenerLineasCesta(en);
        }

    }

}
