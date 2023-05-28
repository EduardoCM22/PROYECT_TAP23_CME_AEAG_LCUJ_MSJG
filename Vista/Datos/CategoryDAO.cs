using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Datos
{
    public class CategoryDAO
    {
        public List<Category> obtenerCategorias()
        {
            List<Category> lista = new List<Category>();
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (SELECT)
                    String select = "Select CategoryId, CategoryName, Description from Categories;";
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
                        Category categoria = new Category(
                            //int.Parse(fila["Clave"].ToString())
                            Convert.ToInt32(fila["CategoryId"]),
                            fila["CategoryName"].ToString(),
                            fila["Description"].ToString()
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
       public int agregar(Category c)
       {
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (SELECT)
                    String select = "insert into categories values(@CategoryId, @CategoryName, @Description)";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;
                    sentencia.Parameters.AddWithValue("@CategoryId", c.CategoryId);
                    sentencia.Parameters.AddWithValue("@CategoryName", c.CategoryName);
                    sentencia.Parameters.AddWithValue("@Description", c.Description);
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
                return 0;
            }
        }
       public int editar(Category c)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (SELECT)
                    String select = "update categories set categoryid=@CategoryId, categoryname=@CategoryName," +
                        "description=@Description where categoryid=@CategoryId";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;
                    sentencia.Parameters.AddWithValue("@CategoryId", c.CategoryId);
                    sentencia.Parameters.AddWithValue("@CategoryName", c.CategoryName);
                    sentencia.Parameters.AddWithValue("@Description", c.Description);
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
                return 0;
            }
       }
    }
}
