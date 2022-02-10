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
    class CADPedido
    {
        private static string constring;
        public CADPedido()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }
        public bool readPedidoDeUsuario(ENPedido en)
        {
            bool readValue = false;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                SqlCommand com = new SqlCommand("SELECT p.numPedido FROM Pedidos p, cestas c, usuarios u WHERE p.cesta = c.numCesta AND p.usuario = u.id AND u.id ='" + en.usuarioPedido + "'", c);
                SqlDataReader dr = com.ExecuteReader();
                c.Open();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        en.numPedidoP = (int)dr[0];
                        en.usuarioPedido = 0;
                        en.cestaPedido = null;
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
        public bool createPedido(ENPedido en)
        {
            bool createValue = false;

            SqlConnection c = new SqlConnection(constring);
            String command;

            command = "INSERT INTO Pedidos (cesta, usuario, fecha) VALUES ('"
                        + en.cestaPedido.NumCesta + "','" + en.usuarioPedido + "','" + en.fechaPedido + "')";


            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(command, c);
                int result = Convert.ToInt32(cmd.ExecuteScalar());

                if (result > 0)
                {
                    createValue = true;
                    en.numPedidoP = result;
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
        public bool deletePedido(ENPedido en)
        {
            bool deleteValue = false;

            SqlConnection c = new SqlConnection(constring);
            string Zdel = " DELETE FROM Pedidos WHERE numPedido = '" + en.numPedidoP + "'";

            try
            {
                c.Open();
                SqlCommand com = new SqlCommand(Zdel, c);
                com.ExecuteNonQuery();
                deleteValue = true;
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
        public bool readLinPed(ENPedido en)
        {
            bool readLinValue = false;
            SqlConnection c = new SqlConnection(constring);
            try
            {
                SqlCommand com = new SqlCommand("SELECT s.nombre, c.numCesta, l.tipoCompra, l.precio FROM LineasPedido l, Series s, Cestas c WHERE l.pedido = '" + en.numPedidoP + "' AND l.serie = s.id AND l.cesta = '" + en.cestaPedido + "'", c);
                SqlDataReader dr = com.ExecuteReader();
                c.Open();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ENLineaPedido l = new ENLineaPedido();
                        ENSerie serie = new ENSerie();
                        serie.nombreSerie = (string)dr[0];
                        ENCesta cesta = new ENCesta();
                        cesta.NumCesta = (int)dr[1];

                        l.Pedido = en;
                        l.Cesta = cesta;
                        l.TipoCompra = (string)dr[2];
                        l.Precio = (int)dr[3];
                        en.linea_Pedidos.Add(l);
                    }
                    dr.Close();
                    readLinValue = true;
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
            return readLinValue;
        }
    }
}