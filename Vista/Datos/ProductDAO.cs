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
    public class ProductDAO
    {
        public List<Product> obtenerProductos()
        {
            List<Product> lista = new List<Product>();
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia select
                    String select = "select ProductID, ProductName, P.SupplierID, S.CompanyName, " +
                        "P.CategoryID, C.CategoryName, UnitPrice,UnitsInStock, ReorderLevel, Discontinued " +
                        "from products P,suppliers S,categories C " +
                        "where S.SupplierID = P.SupplierID and C.CategoryID = P.CategoryID;";
                    DataTable dt = new DataTable();
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
                        Product categoria = new Product(
                            Convert.ToInt32(fila["ProductID"]),
                            fila["ProductName"].ToString(),
                            Convert.ToInt32(fila["SupplierID"]),
                            fila["CompanyName"].ToString(),
                            Convert.ToInt32(fila["CategoryID"]),
                            fila["CategoryName"].ToString(),
                            Convert.ToDouble(fila["UnitPrice"]),
                            Convert.ToInt32(fila["UnitsInStock"]),
                            Convert.ToInt32(fila["ReorderLevel"]),
                            Convert.ToBoolean(fila["Discontinued"])
                            );
                        lista.Add(categoria);
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

        public int agregar(Product product)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (INSERT)
                    String select = "INSERT INTO products (ProductName, SupplierID, CategoryID, " +
                        "UnitPrice, UnitsInStock, Discontinued) VALUES (@ProductName, " +
                        "@SupplierID, @CategoryID, @UnitPrice, @UnitsInStock, @Discontinued)";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@ProductName", product.ProductName);
                    sentencia.Parameters.AddWithValue("@SupplierID", product.SupplierID); // ID del proveedor
                    sentencia.Parameters.AddWithValue("@CategoryID", product.CategoryID); // ID de la categoría
                    sentencia.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                    sentencia.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
                    sentencia.Parameters.AddWithValue("@Discontinued", product.Discontinued);

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

        public int editar(Product product)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (UPDATE)
                    String select = "UPDATE products SET ProductName = @ProductName, " +
                        "SupplierID = @SupplierID, CategoryID = @CategoryID, UnitPrice = @UnitPrice, " +
                        "UnitsInStock = @UnitsInStock, Discontinued = @Discontinued " +
                       "WHERE ProductID = @ProductID";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@ProductName", product.ProductName);
                    sentencia.Parameters.AddWithValue("@SupplierID", product.SupplierID); // ID del proveedor
                    sentencia.Parameters.AddWithValue("@CategoryID", product.CategoryID); // ID de la categoría
                    sentencia.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                    sentencia.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
                    sentencia.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                    sentencia.Parameters.AddWithValue("@ProductID", product.ProductID); // ID del producto a editar

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

        public int Eliminar(int productId)
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

                    sentencia.Parameters.AddWithValue("@ProductId", productId);

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

        public List<Product> reorder()
        {
            List<Product> lista = new List<Product>();
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia select
                    String select = "SELECT p.ProductName, s.CompanyName, " +
                        "CASE WHEN (p.ReorderLevel - p.UnitsInStock) < 0 THEN 0 " +
                        "ELSE (p.ReorderLevel - p.UnitsInStock) END AS Unidades " +
                        "FROM Products p JOIN Suppliers s ON p.SupplierID = s.SupplierID " +
                        "WHERE p.Discontinued = 0;";
                    DataTable dt = new DataTable();
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
                        Product product = new Product(
                            fila["ProductName"].ToString(),
                            fila["CompanyName"].ToString(),
                            Convert.ToInt32(fila["Unidades"])
                            );
                        lista.Add(product);
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

        public List<Product> obtenerAdquirir()
        {
            List<Product> lista = new List<Product>();
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia select
                    String select = "SELECT * FROM PRODUCTS where discontinued = 0;";
                    DataTable dt = new DataTable();
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
                        Product product = new Product(
                            Convert.ToInt32(fila["ProductId"]),
                            fila["ProductName"].ToString(),
                            Convert.ToInt32(fila["UnitsInStock"]),
                            Convert.ToInt32(fila["ReorderLevel"])
                            );
                        lista.Add(product);
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

        public int adquirir(Product prod)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (UPDATE)
                    String select = "UPDATE products SET UnitsInStock = @UnitsInStock " +
                        "WHERE ProductID = @ProductID";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@UnitsInStock", prod.UnitsInStock);
                    sentencia.Parameters.AddWithValue("@ProductID", prod.ProductID); // ID del producto a editar

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

        public List<Product> obtenerNoDescontinuados()
        {
            List<Product> lista = new List<Product>();
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (UPDATE)
                    String select = "SELECT * FROM PRODUCTS where discontinued = 0;";
                    DataTable dt = new DataTable();
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
                        Product product = new Product(
                            Convert.ToInt32(fila["ProductId"]),
                            fila["ProductName"].ToString(),
                            Convert.ToDouble(fila["UnitPrice"]),
                            Convert.ToInt32(fila["UnitsInStock"])
                            );
                        lista.Add(product);
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

        public int actualizar(List<Product> prodAct)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                int filasAfectadas = 0;
                try
                {
                    foreach (Product prod in prodAct)
                    {
                        //Crear la sentencia a ejecutar (INSERT)
                        String select = "update products set UnitsInStock = (UnitsInStock - @Units) " +
                            "where ProductID = @ProductID;";
                        MySqlCommand sentencia = new MySqlCommand();
                        sentencia.CommandText = select;
                        sentencia.Connection = Conexion.conexion;

                        sentencia.Parameters.AddWithValue("@Units", prod.UnitsInStock);
                        sentencia.Parameters.AddWithValue("@ProductID", prod.ProductID);

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