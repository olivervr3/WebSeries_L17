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
    class CADLineaPedido
    {
        private static string constring;
        public CADLineaPedido()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool readLineaPedido(ENLineaPedido en)
        {
            bool readValue = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT l.tipoCompra, l.precio FROM LineasPedido l, Series s WHERE l.pedido = '" + en.Pedido + "' AND l.cesta = '" + en.Cesta.NumCesta + "' AND l.serie = s AND s.nombre = '" + en.Serie.nombreSerie + "'", c);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        en.TipoCompra = (string)dr[0];
                        en.Precio = (int)dr[1];
                    }
                    dr.Close();
                    readValue = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }
            return readValue;
        }
        public bool createLineaPedido(ENLineaPedido en)
        {
            bool createValue = false;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                if (this.readLineaPedido(en))
                {
                    createValue = false;
                }
                else
                {
                    c.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO LineasPedido (pedido, cesta, serie, tipoCompra, precio) VALUES ('"
                        + en.Pedido + "','" + en.Cesta.NumCesta + "',(SELECT id FROM Series WHERE nombre = '" + en.Serie.nombreSerie + "'),'" + en.TipoCompra + "','" + en.Precio + "')", c);

                    com.ExecuteNonQuery();
                    createValue = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }
            return createValue;
        }
        public bool deleteLineaPedido(ENLineaPedido en)
        {
            bool deleteValue = false;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                string Zdel = " DELETE FROM LineasPedido WHERE pedido = '" + en.Pedido+ "' AND cesta = '"
                    + en.Cesta.NumCesta + "' AND serie = (SELECT s.id FROM Series s WHERE s.nombre = '" + en.Serie.nombreSerie + "')";

                if (this.readLineaPedido(en))
                {
                    c.Open();
                    SqlCommand com = new SqlCommand(Zdel, c);
                    com.ExecuteNonQuery();
                    deleteValue = true;
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
            return deleteValue;
        }
        public bool deleteAllLineaPedido(ENLineaPedido en)
        {
            bool deleteAllValues = false;

            SqlConnection c = new SqlConnection(constring);
            string Zdel = "DELETE FROM LineasPedido where pedido = '" + en.Pedido+ "'";

            try
            {

                c.Open();
                SqlCommand com = new SqlCommand(Zdel, c);
                com.ExecuteNonQuery();
                deleteAllValues = true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("User operation has failed. Error: {0}", ex.Message.ToString());
            }
            finally
            {
                c.Close();
            }
            return deleteAllValues;
        }
    }
}
