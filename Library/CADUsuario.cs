using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class CADUsuario
    {
        private string constring;

        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool createUsuario(ENUsuario en)
        {
            SqlConnection nueva_conexion = new SqlConnection(constring);
            string insert = "insert into Usuarios(nombre,apellido1,apellido2,email,contrasena,nif,numTarjeta,numSeguridad,numCaducidad,numTelefono,rol) VALUES ('"
                + en.nombreUsuario + "','" + en.apellido1Usuario + "','" + en.apellido2Usuario + "','" + en.emailUsuario + "','" + en.contrasenaUsuario
                + "','" + en.nifUsuario + "','" + en.numTarjetaUsuario + "','" + en.numSeguridadUsuario + "','" + en.numCaducidadUsuario + "','" + en.numTelefonoUsuario + "','" + en.rolUusario + "')";

            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(insert, nueva_conexion);
                com.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                return false;
            }
            finally
            {
                nueva_conexion.Close();
            }
        }

        public bool readUsuario(ENUsuario en)
        {
            SqlConnection nueva_conexion = new SqlConnection(constring);
            ENUsuario usuario = en;
            string select = "Select * from Usuarios where email ='" + en.emailUsuario + "'";

            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    en.nombreUsuario = dr["nombre"].ToString();
                    en.apellido1Usuario = dr["apellido1"].ToString();
                    en.apellido2Usuario = dr["apellido2"].ToString();
                    en.emailUsuario = dr["email"].ToString();
                    en.contrasenaUsuario = dr["contrasena"].ToString();
                    en.nifUsuario = dr["nif"].ToString();
                    en.numTarjetaUsuario = dr["numTarjeta"].ToString();
                    en.numCaducidadUsuario = dr["numCaducidad"].ToString();
                    en.numSeguridadUsuario = Convert.ToInt32(dr["numSeguridad"]);
                    en.numTelefonoUsuario = Convert.ToInt32(dr["numTelefono"]);
                    en.rolUusario = dr["rol"].ToString();
                }
                dr.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                return false;
            }
            finally
            {
                nueva_conexion.Close();
            }
        }
        public bool updateUsuario(ENUsuario en)
        {
            SqlConnection nueva_conexion = new SqlConnection(constring);
            string update = "Update Usuarios set nombre = '" + en.nombreUsuario + "',apellido1 = '" + en.apellido1Usuario + "',apellido2 = '" + en.apellido2Usuario + "',email = '" + en.emailUsuario + "',contrasena = '" + en.contrasenaUsuario
                + "',nif = '" + en.nifUsuario + "',numTarjeta = '" + en.numTarjetaUsuario + "',numSeguridad = '" + en.numSeguridadUsuario + "',numCaducidad = '" + en.numCaducidadUsuario + "',numTelefono = '" + en.numTelefonoUsuario + "' where email ='" + en.emailUsuario + "'";

            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(update, nueva_conexion);
                com.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                return false;
            }
            finally
            {
                nueva_conexion.Close();
            }
        }


        public bool deleteUsuario(ENUsuario en)
        {
            SqlConnection nueva_conexion = new SqlConnection(constring);
            string delete = "Delete from Usuarios where email = '" + en.emailUsuario + "'";

            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(delete, nueva_conexion);
                com.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                return false;
            }
            finally
            {
                nueva_conexion.Close();
            }
        }

        //Compruebo si hay algún usuario(email) con la contraseña pasada por parámetro en la BBDD
        public bool checkUsuario(string email, string contrasena)
        {
            bool check = false;
            SqlConnection nueva_conexion = new SqlConnection(constring);
            string select = "Select * from Usuarios where email ='" + email + "' and contrasena = '" + contrasena + "'";

            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                check = false;
            }
            finally
            {
                nueva_conexion.Close();
            }
            return check;
        }
        //Compruebo si el número de seguridad corresponde a la tarjeta
        public bool checkTarjeta(string email, int seguridad)
        {
            bool check = false;
            SqlConnection nueva_conexion = new SqlConnection(constring);
            string select = "Select * from Usuarios where email ='" + email + "' and numSeguridad = '" + seguridad + "'";

            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                check = false;
            }
            finally
            {
                nueva_conexion.Close();
            }
            return check;
        }
        //Compruebo si existe un determinado email en la BBDD
        public bool existeUsuario(string email)
        {
            bool existe = false;
            SqlConnection nueva_conexion = new SqlConnection(constring);
            string select = "Select * from Usuarios where email ='" + email + "'";

            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);
                existe = false;
            }
            finally
            {
                nueva_conexion.Close();
            }
            return existe;
        }
        public int IDUsuario(ENUsuario en)
        {
            int id = -1;
            SqlConnection nueva_conexion = new SqlConnection(constring);
            ENUsuario serie = en;
            string select = "Select id from Usuarios where email ='" + en.emailUsuario + "'";

            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr["id"]);
                }
                dr.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed.Error: { 0}", ex.Message);

            }
            finally
            {
                nueva_conexion.Close();
            }
            return id;
        }
        public DataSet SacarUsuarios() {
            DataSet bdvirtual = new DataSet();

            SqlConnection c = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("select * from Usuarios", c);
            da.Fill(bdvirtual);
            return bdvirtual;
        }
    }
}