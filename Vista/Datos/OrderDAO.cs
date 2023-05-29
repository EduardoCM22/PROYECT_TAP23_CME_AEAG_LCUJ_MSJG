﻿using Modelos;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class OrderDAO
    {
        public List<Order> obtenerVentas()
        {
            List<Order> lista = new List<Order>();
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (SELECT)
                    String select = "SELECT o.OrderID, e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) EmployeeName, " +
                        "c.CustomerID, c.CompanyName CustomerName, o.OrderDate, sum(od.UnitPrice*od.Quantity) " +
                        "Total FROM Orders o JOIN Employees e ON e.EmployeeID = o.EmployeeID " +
                        "JOIN Customers c ON c.CustomerID = o.CustomerID natural join `order details` od " +
                        "group by o.OrderID, e.EmployeeID, EmployeeName, c.CustomerID, CustomerName, o.OrderDate;";
                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = sentencia;

                    //Llenar el datatable
                    da.Fill(dt);
                    //Crear un objeto categoría por cada fila de la tabla y añadirlo a la lista
                    foreach (DataRow fila in dt.Rows)
                    {
                        Order venta = new Order(

                           Convert.ToInt32(fila["OrderID"]),
                           Convert.ToInt32(fila["EmployeeID"]),
                           fila["EmployeeName"].ToString(),
                           fila["CustomerID"].ToString(),
                           fila["CustomerName"].ToString(),
                           fila["OrderDate"].ToString(),
                           Convert.ToDouble(fila["Total"])
                           );
                        ;
                        lista.Add(venta);
                    }
                    return lista;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return null;
            }
        }

        public int Eliminar(int id)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (UPDATE)
                    String select = "delete from orders where OrderID = @OrderID;";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@OrderID", id);

                    //Ejercutar el comando 
                    int filasAfectadas = Convert.ToInt32(sentencia.ExecuteNonQuery());
                    return filasAfectadas;
                }
                catch (MySqlException e)
                {
                    if (e.Number == 1451)
                    {
                        return 1451;
                    }
                    else
                    {
                        return 0;
                    }
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

        public int insertar(Order order)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (INSERT)
                    String select = "insert into orders(CustomerID, EmployeeID, OrderDate) " +
                        "values(@CustomerID, @EmployeeID, current_date()); select last_insert_id()";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    sentencia.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);

                    //Ejercutar el comando 
                    int filasAfectadas = Convert.ToInt32(sentencia.ExecuteScalar());
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

        //public int verificar(int id, int unidades)
        //{
        //    //Conectarme
        //    if (Conexion.Conectar())
        //    {
        //        try
        //        {
        //            //Crear la sentencia a ejecutar (INSERT)
        //            String select = "select (UnitsInStock-@Units) from products " +
        //                "where productid = @ProductID;";
        //            MySqlCommand sentencia = new MySqlCommand();
        //            sentencia.CommandText = select;
        //            sentencia.Connection = Conexion.conexion;

        //            sentencia.Parameters.AddWithValue("@ProductID", id);
        //            sentencia.Parameters.AddWithValue("@Units", unidades);

        //            //Ejercutar el comando 
        //            int filasAfectadas = Convert.ToInt32(sentencia.ExecuteScalar());
        //            return filasAfectadas;
        //        }
        //        finally
        //        {
        //            Conexion.Desconectar();
        //        }
        //    }
        //    else
        //    {
        //        //Devolvemos un cero indicando que no se insertó nada
        //        return -1;
        //    }
        //}
    }
}
