using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Library
{
    public class CADMisSeries
    {
        private string constring;

        public CADMisSeries()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool AgregarAMisSeries(ENMisSeries en)
        {
            bool returnValue = false;
            SqlConnection connection = new SqlConnection(constring);

            String query = "insert into misseries (serie, usuario) values ( (select id from series where nombre = '"+en.Serie.nombreSerie+"') , (select id from usuarios where email = '"+en.Usuario.emailUsuario+"') );";
            
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                
                int result = cmd.ExecuteNonQuery();
               
                if (result > 0)
                {
                    returnValue = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return returnValue;

        }

        public bool EliminarDeMisSeries(ENMisSeries en)
        {
            bool returnValue = false;
            SqlConnection connection = new SqlConnection(constring);

            String query = "delete from misseries where serie = (select id from series where nombre = '" + en.Serie.nombreSerie + "') and usuario = (select id from usuarios where email = '"+en.Usuario.emailUsuario+"');";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@c", en.Cesta.NumCesta);
                //cmd.Parameters.AddWithValue("@s", en.Serie.nombreSerie);


                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    returnValue = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return returnValue;

        }

        public bool ObtenerMisSeries(ENMisSeries en)
        {
            bool returnValue = false;

            SqlConnection connection = new SqlConnection(constring);

            String query = "select s.nombre from misseries ms, series s where ms.usuario = (select id from usuarios where email = '"+en.Usuario.emailUsuario+"') and ms.serie = s.id;";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@c", en.Cesta.NumCesta);
                //cmd.Parameters.AddWithValue("@s", en.Serie.nombreSerie);


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ENSerie s = new ENSerie();
                        s.nombreSerie = (string)reader[0];
                        en.Series.Add(s);
                    }
                    reader.Close();
                    returnValue = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return returnValue;

        }

        
        public bool EstaENMisSeries(ENMisSeries en)
        {
            bool returnValue = false;

            SqlConnection connection = new SqlConnection(constring);

            String query = "select ms.serie from misseries ms where ms.usuario = (select id from usuarios where email = '" + en.Usuario.emailUsuario + "') and ms.serie = (select id from series where nombre = '"+en.Serie.nombreSerie+"') ;";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@c", en.Cesta.NumCesta);
                //cmd.Parameters.AddWithValue("@s", en.Serie.nombreSerie);


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    returnValue = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return returnValue;

        }

    }

}
