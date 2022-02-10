using System;
using System.Data;

namespace Library
{
	public class ENUsuario
	{
		private string nombre;
		private string apellido1;
		private string apellido2;
		private string email;
		private string contrasena;
		private string nif;
		private string numTarjeta;
		private string numCaducidad;
		private int numSeguridad;
		private int numTelefono;
		private string rol;

		public string nombreUsuario
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public string apellido1Usuario
		{
			get { return apellido1; }
			set { apellido1 = value; }
		}
		public string apellido2Usuario
		{
			get { return apellido2; }
			set { apellido2 = value; }
		}
		public string emailUsuario
		{
			get { return email; }
			set { email = value; }
		}
		public string contrasenaUsuario
		{
			get { return contrasena; }
			set { contrasena = value; }
		}
		public string nifUsuario
		{
			get { return nif; }
			set { nif = value; }
		}
		public string numTarjetaUsuario
		{
			get { return numTarjeta; }
			set { numTarjeta = value; }
		}
		public string numCaducidadUsuario
		{
			get { return numCaducidad; }
			set { numCaducidad = value; }
		}
		public int numSeguridadUsuario
		{
			get { return numSeguridad; }
			set { numSeguridad = value; }
		}
		public int numTelefonoUsuario
		{
			get { return numTelefono; }
			set { numTelefono = value; }
		}
		public string rolUusario
		{
			get { return rol; }
			set { rol = value; }
		}
		//Constructor por defecto
		public ENUsuario()
		{
			this.nombre = "";
			this.apellido1 = "";
			this.apellido2 = "";
			this.email = "";
			this.contrasena = "";
			this.nif = "";
			this.numTarjeta = "";
			this.numCaducidad = "";
			this.numSeguridad = 0;
			this.numTelefono = 0;
			this.rol = "user";
		}
		//Constructor con parámeros
		public ENUsuario(string nombre, string apellido1, string apellido2, string email, string contrasena, string nif, string numTarjeta, string numCaducidad, int numSeguridad, int numTelefono)
		{
			this.nombre = nombre;
			this.apellido1 = apellido1;
			this.apellido2 = apellido2;
			this.email = email;
			this.contrasena = contrasena;
			this.nif = nif;
			this.numTarjeta = numTarjeta;
			this.numCaducidad = numCaducidad;
			this.numSeguridad = numSeguridad;
			this.numTelefono = numTelefono;
			this.rol = "user";
		}
		//Crear usuario nuevo
		public bool createUsuario()
		{
			CADUsuario cad = new CADUsuario();
			return cad.createUsuario(this);
		}
		//Cargo los datos del usuario
		public bool readUsuario()
		{
			CADUsuario cad = new CADUsuario();
			return cad.readUsuario(this);
		}
		//Modifico el usuario
		public bool updateUsuario()
		{
			CADUsuario cad = new CADUsuario();
			return cad.updateUsuario(this);
		}
		//Borro el usuario
		public bool deleteUsuario()
		{
			CADUsuario cad = new CADUsuario();
			return cad.deleteUsuario(this);
		}
		//Compruebo que exista un usuario con esa contraseña
		public bool checkUsuario()
		{
			CADUsuario cad = new CADUsuario();
			return cad.checkUsuario(this.email, this.contrasena);
		}
		//Compruebo que el numero de seguridad pasado por parámetro sea igual al del usuario
		public bool checkTarjeta(int numSeguridad)
		{
			CADUsuario cad = new CADUsuario();
			return cad.checkTarjeta(this.email, numSeguridad);
		}
		//Devuelvo true si existe el usuario
		public bool existeUsuario()
		{
			CADUsuario cad = new CADUsuario();
			return cad.existeUsuario(this.email);
		}
		//Getter del ID del usuario
		public int IDUsuario()
		{
			CADUsuario cad = new CADUsuario();
			return cad.IDUsuario(this);
		}
		public DataSet SacarUsuarios() 
		{
			CADUsuario cad = new CADUsuario();
			return cad.SacarUsuarios();
		}
	}
}
