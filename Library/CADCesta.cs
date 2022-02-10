using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Library
{
    public class CADCesta
    {
        private string constring;

        public CADCesta()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool CrearCesta(ENCesta en)
        {
            bool returnValue = false;
            SqlConnection connection = new SqlConnection(constring);

            String query;

            if (en.Usuario != null)
            {
                query = "insert into cestas (usuario) select id from usuarios where email ='" + en.Usuario.emailUsuario + "'; SELECT SCOPE_IDENTITY()";
            }
            else {
                query = "insert into cestas (usuario) values (null); SELECT SCOPE_IDENTITY()";
            }

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@usuario", en.Usuario);

                //int result = cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(cmd.ExecuteScalar());

                if (result > 0)
                {
                    returnValue = true;
                    en.NumCesta = result;
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

        public bool EliminarCesta(ENCesta en)
        {
            bool returnValue = false;
            SqlConnection connection = new SqlConnection(constring);

            String query = "delete from cestas where numCesta = @num;";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@num", en.NumCesta);

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

        public bool ActualizarCesta(ENCesta en)
        {
                 bool returnValue = false;
                SqlConnection connection = new SqlConnection(constring);

                String query = "update cestas set usuario = @u;";

                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@u", en.Usuario.IDUsuario());
                    
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

        public bool ObtenerCesta(ENCesta en)
        {
            bool returnValue = false;

            SqlConnection connection = new SqlConnection(constring);

            String query = "select c.numCesta, u.email from cestas c, usuarios u where c.numCesta = @num and c.usuario = u.id;";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@num", en.NumCesta);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        en.NumCesta = (int)reader[0];
                        ENUsuario usu = new ENUsuario();
                        usu.emailUsuario = reader[1] != null ? (string)reader[1] : null;
                        en.Usuario = usu;
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

        public bool ObtenerCestaDeUsuario(ENCesta en)
        {
            bool returnValue = false;

            SqlConnection connection = new SqlConnection(constring);

            String query = "select c.numCesta from cestas c, usuarios u where c.usuario = u.id and u.email = '"+en.Usuario.emailUsuario+"';";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        en.NumCesta = (int)reader[0];
                        //en.Usuario = null; //(int)reader[1];
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

        public bool ObtenerLineasCesta(ENCesta en)
        {
            bool returnValue = false;

            SqlConnection connection = new SqlConnection(constring);

            String query = "select lc.tipoCompra, lc.precio, s.nombre from LineasCesta lc, series s where lc.cesta = @c and lc.serie = s.id;";

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@c", en.NumCesta);
                

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ENSerie serie = new ENSerie();
                        serie.nombreSerie = (string)reader[2];

                        ENLineaCesta l = new ENLineaCesta();
                        l.Cesta = en;
                        l.TipoCompra = (string)reader[0];
                        l.Precio = (double)reader[1];
                        l.Serie = serie;

                        en.Lineas.Add(l);
                        
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


    }
}
