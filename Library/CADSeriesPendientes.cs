using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Library
{
    public class CADSeriesPendientes
    {
        private static string constring;
        public CADSeriesPendientes()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public ENSerie[] readPendientes (ENSeriesPendientes en)
        {
            List<ENSerie> pendientes = new List<ENSerie>();
            SqlConnection c = new SqlConnection(constring);
            ENSerie pendiente;
            String query = "SELECT s.* FROM SeriesPendientes p, Series s, Usuarios u WHERE p.usuario = @usuari AND u.id = p.usuario AND s.id = p.serie";

            try
            {
                c.Open();

                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@usuari", en.usuarioPendiente);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pendiente = new ENSerie(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]));
                    pendientes.Add(pendiente);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }
            return pendientes.ToArray();
        }

        public bool createPendientes (ENSeriesPendientes en)
        {
            // Hara uso de los datos representados por 'en'.
            SqlConnection c = new SqlConnection(constring);

            //si this.readUsuario(en) => true, existe => error
            // si no, no existe => add
            try
            {
                    c.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO SeriesPendientes (usuario,serie) VALUES ('"
                        + en.usuarioPendiente + "','" + en.seriePendiente + "')", c);

                    com.ExecuteNonQuery();
                    return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
                return false;
            }
            finally
            {
                c.Close();
            }
        }
        public bool deletePendientes (ENSeriesPendientes en)
        {
            SqlConnection c = new SqlConnection(constring);
            string Zdel = " DELETE FROM SeriesPendientes WHERE usuario = '" + en.usuarioPendiente + "' AND serie = '" + en.seriePendiente + "'";

            try
            {
                    c.Open();
                    SqlCommand com = new SqlCommand(Zdel, c);
                    com.ExecuteNonQuery();
                    return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message.ToString());
                return false;
            }
            finally
            {
                c.Close();
            }
        }
        public bool usuarioTienePendientes (ENSeriesPendientes en, int serie)
        {
            SqlConnection c = new SqlConnection(constring);
            string Zdel = " SELECT FROM SeriesPendientes WHERE usuario = '" + en.usuarioPendiente + "' AND serie = '" + serie + "'";
            bool existe = false;
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand(Zdel, c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    existe = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message.ToString());
            }
            finally
            {
                c.Close();
                
            }
            return existe;
        }
    }
}
