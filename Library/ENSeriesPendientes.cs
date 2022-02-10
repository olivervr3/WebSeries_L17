using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENSeriesPendientes
    {
        private int usuario;
        private int serie;
        private string nombre;
        private string categoria;
        private string imagen;
        private string descripcion;
        private string trailer;
        private int temporadas;
        private int precio;

        public int usuarioPendiente
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public int seriePendiente
        {
            get { return serie; }
            set { serie = value; }
        }
        public string nombreSerie
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string categoriaSerie
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public string imagenSerie
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public string descripcionSerie
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string trailerSerie
        {
            get { return trailer; }
            set { trailer = value; }
        }
        public int temporadasSerie
        {
            get { return temporadas; }
            set { temporadas = value; }
        }
        public int precioSerie
        {
            get { return precio; }
            set { precio = value; }
        }
        public ENSeriesPendientes()
        {
            this.usuario = 0;
            this.serie = 0;
        }
        public ENSeriesPendientes(int us, int se)
        {
            this.usuario = us;
            this.serie = se;
        }

        public ENSerie[] readPendientes ()
        {
            CADSeriesPendientes cad = new CADSeriesPendientes();
            return cad.readPendientes(this);
        }

        public bool createPendientes ()
        {
            CADSeriesPendientes en = new CADSeriesPendientes();
            return en.createPendientes(this);
        }

        public bool deletePendientes ()
        {
            CADSeriesPendientes en = new CADSeriesPendientes();
            return en.deletePendientes(this);
        }
        public bool usuarioTienePendientes (int serie)
        {
            CADSeriesPendientes en2 = new CADSeriesPendientes();
            return en2.usuarioTienePendientes(this, serie);
        }
    }
}
