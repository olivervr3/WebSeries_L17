using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Library
{
    public class CADLineaCesta
    {
        private string constring;

        public CADLineaCesta()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool AgregarALineaCesta(ENLineaCesta en)
        {
            bool returnValue = false;
            SqlConnection connection = new SqlConnection(constring);

            String query = "insert into LineasCesta (cesta, serie, tipoCompra, precio) values (@c, (select id from series where nombre = '"+ en.Serie.nombreSerie +"'), @t, @p);";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@c", en.Cesta.NumCesta);
                //cmd.Parameters.AddWithValue("@s", en.Serie.nombreSerie);
                cmd.Parameters.AddWithValue("@t", en.TipoCompra);
                cmd.Parameters.AddWithValue("@p", en.Precio);

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

        public bool EliminarDeLineaCesta(ENLineaCesta en)
        {
            bool returnValue = false;
            SqlConnection connection = new SqlConnection(constring);

            String query = "delete from lineascesta where cesta = "+en.Cesta.NumCesta+" and serie = (select id from series where nombre = '"+en.Serie.nombreSerie+"');";

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

        public bool ObtenerLineaCesta(ENLineaCesta en)
        {
                bool returnValue = false;

                SqlConnection connection = new SqlConnection(constring);

                String query = "select lc.tipoCompra, lc.precio from LineasCesta lc, series s where lc.cesta = @c and lc.serie = s.id and s.nombre = @s;";

                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@c", en.Cesta.NumCesta);
                    cmd.Parameters.AddWithValue("@s", en.Serie.nombreSerie);


                SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            en.TipoCompra = (string)reader[0];
                            en.Precio = (double)reader[1];
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

        public bool ActualizarLineaCesta(ENLineaCesta en)
        {
                 bool returnValue = false;
                SqlConnection connection = new SqlConnection(constring);

                String query = "update lineascesta set tipoCompra = @tc, precio = @p where cesta = @c and serie = (select id from series where nombre = @s);";

                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@tc", en.TipoCompra);
                    cmd.Parameters.AddWithValue("@p", en.Precio);
                    cmd.Parameters.AddWithValue("@c", en.Cesta.NumCesta);
                    cmd.Parameters.AddWithValue("@s", en.Serie.nombreSerie);


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

        public bool EliminarTodasLineaCesta(ENLineaCesta en)
        {
            bool returnValue = false;
            SqlConnection connection = new SqlConnection(constring);

            String query = "delete from lineascesta where cesta = "+en.Cesta.NumCesta+";";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                

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

        public bool ExisteSerieEnCestaOMisSeries(int numCesta, string nombreSerie, string emailUsuario)
        {
            bool returnValue = false;

            SqlConnection connection = new SqlConnection(constring);

            String query = "select lc.tipoCompra, lc.precio from LineasCesta lc, series s where lc.cesta = @c and lc.serie = s.id and s.nombre = @s;";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@c", numCesta);
                cmd.Parameters.AddWithValue("@s", nombreSerie);


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
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

            if (returnValue == false && emailUsuario != null) {
                ENSerie s = new ENSerie();
                s.nombreSerie = nombreSerie;

                ENUsuario u = new ENUsuario();
                u.emailUsuario = emailUsuario;

                ENMisSeries ms = new ENMisSeries();
                ms.Serie = s;
                ms.Usuario = u;
                returnValue = ms.EstaENMisSeries(ms);
            }

            return returnValue;
        }

    }
}
