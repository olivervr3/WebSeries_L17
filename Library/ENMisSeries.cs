using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENMisSeries
    {
        private ENSerie serie;
        private ENUsuario usuario;
        private List<ENSerie> series;
       
        public ENSerie Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        public ENUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public List<ENSerie> Series
        {
            get { return series; }
            set { series = value; }
        }

        public ENMisSeries()
        {
            series = new List<ENSerie>();
        }

        public ENMisSeries(ENSerie serie, ENUsuario usuario, List<ENSerie> series)
        {
            this.serie = serie;
            this.usuario = usuario;
            this.series = series;
        }

        /// <summary>
        /// Añadir una serie a un usuario en mis series
        /// </summary>
        /// <param name="en">El usuario y la serie a añadir a mis series</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool AgregarAMisSeries(ENMisSeries en)
        {
            CADMisSeries cad = new CADMisSeries();
            return cad.AgregarAMisSeries(en);
        }

        /// <summary>
        /// Eliminar una serie en mis series de un usuario
        /// </summary>
        /// <param name="en">El usuario y la serie a eliminar de mis series</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool EliminarDeMisSeries(ENMisSeries en)
        {
            CADMisSeries cad = new CADMisSeries();
            return cad.EliminarDeMisSeries(en);
        }

        /// <summary>
        /// Obtener las mis series de un usuario
        /// </summary>
        /// <param name="en">El usuario del que extraer las mis series</param>
        /// <returns>Si la operación ha tenido éxito</returns>
        public bool ObtenerMisSeries(ENMisSeries en)
        {
            CADMisSeries cad = new CADMisSeries();
            return cad.ObtenerMisSeries(en);
        }

        /// <summary>
        /// Comprueba si una serie está en mis series
        /// </summary>
        /// <param name="en">La serie y el usuario</param>
        /// <returns>True si está en mis serios y false lo contrario</returns>
        public bool EstaENMisSeries(ENMisSeries en)
        {
            CADMisSeries cad = new CADMisSeries();
            return cad.EstaENMisSeries(en);
        }

    }
}
