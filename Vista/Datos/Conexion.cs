using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        public static MySqlConnection conexion;
        private static string ip = "localhost";
        private static string usuario = "root";
        private static string password = "root";

        public static bool Conectar()
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open) return true;

                conexion = new MySqlConnection();
                //conexion.ConnectionString = "server=localhost;uid=root;pwd=root;database=northwind";
                conexion.ConnectionString = $"server={ip};uid={usuario};pwd={password};database=northwind";
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
            ip = valueip;
            usuario = valueusuario;
            password = valuepassword;
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open) return true;

                conexion = new MySqlConnection();
                conexion.ConnectionString = $"server={ip};uid={usuario};pwd={password};database=northwind";
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

    }
}