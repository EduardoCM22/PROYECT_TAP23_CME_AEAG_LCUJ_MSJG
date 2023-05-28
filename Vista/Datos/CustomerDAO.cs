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
    public class CustomerDAO
    {


        public List<Customer> GetAllCustomers()
        {
            List<Customer> lista = new List<Customer>();
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia select
                    String select = @"SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax 
                     FROM Customers";

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
                        Customer customer = new Customer();
                        customer.CustomerID = fila["CustomerID"].ToString();
                        customer.CompanyName = fila["CompanyName"].ToString();
                        customer.ContactName = fila["ContactName"].ToString();
                        customer.ContactTitle = fila["ContactTitle"].ToString();
                        customer.Address = fila["Address"].ToString();
                        customer.City = fila["City"].ToString();
                        customer.Region = fila["Region"].ToString();
                        customer.PostalCode = fila["PostalCode"].ToString();
                        customer.Country = fila["Country"].ToString();
                        customer.Phone = fila["Phone"].ToString();
                        customer.Fax = fila["Fax"].ToString();

                        lista.Add(customer);
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
