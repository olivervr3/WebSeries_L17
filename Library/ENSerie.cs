using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ENSerie
    {
		private string nombre;
		private string categoria;
		private string imagen;
		private string descripcion;
		private string trailer;
		private int temporadas;
		private int precio;

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
		//Constructor por defecto
		public ENSerie() 
		{
			this.nombre = "";
			this.categoria = "";
			this.imagen = "";
			this.descripcion = "";
			this.trailer = "";
			this.temporadas = 0;
			this.precio = 0;
		}
		//Constructor con parámeros
		public ENSerie(string nombre, string categoria, string imagen, string descripcion, string trailer, int temporadas, int precio)
		{
			this.nombre = nombre;
			this.categoria = categoria;
			this.imagen = imagen;
			this.descripcion = descripcion;
			this.trailer = trailer;
			this.temporadas = temporadas;
			this.precio = precio;
		}
		//Crear serie
		public bool createSerie()
		{
			CADSerie cad = new CADSerie();
			return cad.createSerie(this);
		}
		//Cargo los datos de la serie
		public bool readSerie()
		{
			CADSerie cad = new CADSerie();
			return cad.readSerie(this);
		}
		//Devuelvo una lista de las series
		public ENSerie[] SacarSeries()
		{
			CADSerie cad = new CADSerie();
			return cad.SacarSeries();
		}
		//Devuelvo una lista de las series de la categoría pasada por parámetro
		public ENSerie[] SacarSeriesPorCategoria(string cat)
		{
			CADSerie cad = new CADSerie();
			return cad.SacarSeriesPorCategoria(cat);
		}
		public ENSerie[] SacarSeries(string cat)
		{
			CADSerie cad = new CADSerie();
			return cad.SacarSeries(cat);
		}
		//Getter del id de la serie
		public int IDSerie()
		{
			CADSerie cad = new CADSerie();
			return cad.IDSerie(this);
		}
	}
}
