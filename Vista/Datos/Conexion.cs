using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Properties;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        public static MySqlConnection conexion;

        public static bool Conectar()
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open) return true;

                conexion = new MySqlConnection();
                //conexion.ConnectionString = "server=localhost;uid=root;pwd=root;database=northwind";
                conexion.ConnectionString = $"server={Settings.Default.Host};uid={Settings.Default.Usuario};pwd={Settings.Default.Password};database=northwind";
                //conexion.ConnectionString = "server=" + ip + ";uid=" + usuario + ";pwd=" + usuario + ";database=northwind";
                conexion.Open();

                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static void Desconectar()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }

        public static bool Conectar(string valueip, string valueusuario, string valuepassword)
        {
            Settings.Default.Host = valueip;
            Settings.Default.Usuario = valueusuario;
            Settings.Default.Password = valuepassword;
            return Conectar();
        }

    }
}