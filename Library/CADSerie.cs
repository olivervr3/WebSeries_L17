using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class CADSerie
    {
        private string constring;

        public CADSerie()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool createSerie(ENSerie en)
        {
            SqlConnection nueva_conexion = new SqlConnection(constring);
            string insert = "insert into Series(nombre,categoria,imagen,descripcion,trailer,temporadas,precio) VALUES ('"
                + en.nombreSerie + "','" + en.categoriaSerie + "','" + en.imagenSerie + "','" + en.descripcionSerie + "','" + en.trailerSerie
                + "','" + en.temporadasSerie + "','" + en.precioSerie + "')";

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
        public bool readSerie(ENSerie en)
        {
            SqlConnection nueva_conexion = new SqlConnection(constring);
            ENSerie serie = en;
            string select = "Select * from Series where nombre ='" + en.nombreSerie + "'";
            
            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    en.nombreSerie = dr["nombre"].ToString();
                    en.categoriaSerie = dr["categoria"].ToString();
                    en.imagenSerie = dr["imagen"].ToString();
                    en.descripcionSerie = dr["descripcion"].ToString();
                    en.trailerSerie = dr["trailer"].ToString();
                    en.temporadasSerie = Convert.ToInt32(dr["temporadas"]);
                    en.precioSerie = Convert.ToInt32(dr["precio"]);
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
        public ENSerie[] SacarSeries() 
        {
            List<ENSerie> series = new List<ENSerie>();
            SqlConnection nueva_conexion = new SqlConnection(constring);
            ENSerie serie;
            string select = "Select * from Series";
            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    serie = new ENSerie(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]));
                    series.Add(serie);
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
            return series.ToArray();
        }
        public ENSerie[] SacarSeriesPorCategoria(string categoria)
        {
            List<ENSerie> series = new List<ENSerie>();
            SqlConnection nueva_conexion = new SqlConnection(constring);
            ENSerie serie;
            string select = "Select * from Series where categoria ='" + categoria + "'";
            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    serie = new ENSerie(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]));
                    series.Add(serie);
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
            return series.ToArray();
        }
        public ENSerie[] SacarSeries(string categoria)
        {
            List<ENSerie> series = new List<ENSerie>();
            SqlConnection nueva_conexion = new SqlConnection(constring);
            ENSerie serie;
            string select = "Select * from Series where nombre ='" + categoria + "'";
            try
            {
                nueva_conexion.Open();
                SqlCommand com = new SqlCommand(select, nueva_conexion);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    serie = new ENSerie(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToInt32(dr[7]));
                    series.Add(serie);
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
            return series.ToArray();
        }
        public int IDSerie(ENSerie en) {
            int id = -1;
            SqlConnection nueva_conexion = new SqlConnection(constring);
            ENSerie serie = en;
            string select = "Select id from Series where nombre ='" + en.nombreSerie + "'";

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
    }
}
