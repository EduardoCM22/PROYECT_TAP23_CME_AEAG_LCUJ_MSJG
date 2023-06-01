using Modelos;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OrderDetailsDAO
    {
        public int insertar(List<OrderDetails> orderDetails)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                int filasAfectadas = 0;
                try
                {
                    foreach (OrderDetails ordDet in orderDetails)
                    {
                        //Crear la sentencia a ejecutar (INSERT)
                        String select = "insert into `order details`(OrderID, ProductID, UnitPrice, Quantity) " +
                            "values(@OrderID, @ProductID, @UnitPrice, @Quantity);";
                        MySqlCommand sentencia = new MySqlCommand();
                        sentencia.CommandText = select;
                        sentencia.Connection = Conexion.conexion;

                        sentencia.Parameters.AddWithValue("@OrderID", ordDet.OrderID);
                        sentencia.Parameters.AddWithValue("@ProductID", ordDet.ProductID);
                        sentencia.Parameters.AddWithValue("@UnitPrice", ordDet.UnitPrice);
                        sentencia.Parameters.AddWithValue("@Quantity", ordDet.Quantity);

                        //Ejercutar el comando 
                        filasAfectadas += Convert.ToInt32(sentencia.ExecuteNonQuery());
                    }
                    return filasAfectadas;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                //Devolvemos un cero indicando que no se insertó nada
                return 0;
            }
        }

    }
}
