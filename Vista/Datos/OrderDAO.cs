using Modelos;
using MySql.Data.MySqlClient;
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
                    String select2 = "Select SupplierId, CompanyName from Suppliers;";

                    String select = "SELECT Orders.OrderID, Employees.EmployeeID, CONCAT(Employees.FirstName,\" \" , " +
                        "Employees.LastName) AS EmployeeName, Customers.CustomerID  ,Customers.CompanyName AS CustomerName, " +
                        "Orders.OrderDate, Orders.Freight " +
                        "FROM Orders JOIN Employees ON Employees.EmployeeID = Orders.EmployeeID " +
                        "JOIN Customers ON Customers.CustomerID = Orders.CustomerID;";
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
                           Convert.ToDouble(fila["Freight"])
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

        public int agregar(Product prod)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (INSERT)
                    String select = "INSERT INTO products (ProductName, SupplierID, CategoryID, UnitPrice, UnitsInStock, Discontinued) " +
                       "VALUES (@ProductName, @SupplierID, @CategoryID, @UnitPrice, @UnitsInStock, @Discontinued)";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@ProductName", prod.ProductName);
                    sentencia.Parameters.AddWithValue("@SupplierID", prod.SupplierID); // ID del proveedor
                    sentencia.Parameters.AddWithValue("@CategoryID", prod.CategoryID); // ID de la categoría
                    sentencia.Parameters.AddWithValue("@UnitPrice", prod.UnitPrice);
                    sentencia.Parameters.AddWithValue("@UnitsInStock", prod.UnitsInStock);
                    sentencia.Parameters.AddWithValue("@Discontinued", prod.Discontinued);
                    //Ejercutar el comando 
                    int filasAfectadas = Convert.ToInt32(sentencia.ExecuteNonQuery());
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

        public int Eliminar(int id)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (UPDATE)
                    String select = "Delete from products where ProductId=@ProductId;";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;
                    sentencia.Parameters.AddWithValue("@ProductId", id);
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

    }
}
