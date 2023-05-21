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
                    String select = "select ProductID,ProductName,P.SupplierID,S.CompanyName,P.CategoryID,C.CategoryName,UnitPrice,UnitsInStock, ReorderLevel,Discontinued " +
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
    }
}
