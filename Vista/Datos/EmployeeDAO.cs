using Modelos;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EmployeeDAO
    {
        public Employee login(String usuario, String password)
        {
            Employee employee = null;
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (select)
                    String select = "select EmployeeID, FirstName, LastName, Title, " +
                        "PostalCode, ReportsTo from Employees " +
                        "where UserName=@usuario and Password=@password";
                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand(select);

                    //Asignar los parámetros
                    sentencia.Parameters.AddWithValue("@usuario", usuario);
                    sentencia.Parameters.AddWithValue("@password", password);

                    sentencia.Connection = Conexion.conexion;
                    MySqlDataAdapter da = new MySqlDataAdapter(sentencia);

                    //Llenar el datatable
                    da.Fill(dt);
                    //Revisar si hubo resultados
                    if (dt.Rows.Count > 0)
                    {
                        DataRow fila = dt.Rows[0];
                        if (Convert.IsDBNull(fila["ReportsTo"]))
                        {
                            employee = new Employee(
                            Convert.ToInt32(fila["EmployeeId"]),
                            fila["FirstName"].ToString(),
                            fila["LastName"].ToString(),
                            fila["Title"].ToString(),
                            fila["PostalCode"].ToString(),
                            0);
                        }
                        else
                        {
                            employee = new Employee(
                            Convert.ToInt32(fila["EmployeeId"]),
                            fila["FirstName"].ToString(),
                            fila["LastName"].ToString(),
                            fila["Title"].ToString(),
                            fila["PostalCode"].ToString(),
                            Convert.ToInt32(fila["ReportsTo"]));
                        }
                    }
                    return employee;
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

        public List<Employee> obtenerEmpleados()
        {
            List<Employee> lista = new List<Employee>();
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia select
                    String select = "select EmployeeID, FirstName, LastName, Title, " +
                        "PostalCode, ReportsTo from employees;";
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
                        int reportsTo = 0; // Valor predeterminado en caso de DBNull
                        if (!Convert.IsDBNull(fila["ReportsTo"]))
                        {
                            reportsTo = Convert.ToInt32(fila["ReportsTo"]);
                        }
                        Employee Empleado = new Employee(
                             Convert.ToInt32(fila["EmployeeID"]),
                             fila["FirstName"].ToString(),
                             fila["LastName"].ToString(),
                             fila["Title"].ToString(),
                             fila["PostalCode"].ToString(),
                             reportsTo
                            );
                        lista.Add(Empleado);
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

        public int agregar(Employee employee)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    String select = "insert into employees(LastName, FirstName, Title, PostalCode, " +
                        "ReportsTo, Notes) values(@LastName, @FirstName, @Title, " +
                        "@PostalCode, @ReportsTo, '');";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@LastName", employee.LastName);
                    sentencia.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    sentencia.Parameters.AddWithValue("@Title", employee.Title);
                    sentencia.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                    sentencia.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);

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

        public int editar(Employee employee)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (UPDATE)
                    String select = "update employees set LastName = @LastName, FirstName = @FirstName, " +
                        "Title = @Title, PostalCode = @PostalCode, ReportsTo = @ReportsTo " +
                        "where EmployeeID = @EmployeeID;";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    sentencia.Parameters.AddWithValue("@LastName", employee.LastName);
                    sentencia.Parameters.AddWithValue("@@FirstName", employee.FirstName);
                    sentencia.Parameters.AddWithValue("@Title", employee.Title);
                    sentencia.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                    sentencia.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);

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
                    String select = "Delete from employees where EmployeeID=@EmployeeID;";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;

                    sentencia.Parameters.AddWithValue("@EmployeeID", id);

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
