using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace Api_PlaceMyBet.Controllers
{
    public class DataBaseRepository
    {

        static string server = "server=127.0.0.1;";
        static string port = "port=3306;";
        static string database = "database=placemybet;";
        static string usuario = "uid=root;";
        static string password = "pwd=;";
        static string convert = "Convert Zero Datetime=True;";
        static string connectionstring = server + port + database + usuario + password + convert;
        /*

        static MySqlConnection conexion = new MySqlConnection(connectionstring);

        public static MySqlConnection Conexion { get => conexion; }


        public static bool AbrirConexion() {


            try
            {
                conexion.Open();                
                Debug.WriteLine("Conexion correcta");
                return true;
            }
            catch (MySqlException ex) {

                
                Debug.WriteLine("No se ha podido realizar la conexion con la BD");
                
                return false;


            }        
        }
        public static bool CerrarConexion()
        {
            try
            {
                conexion.Close();
                Debug.WriteLine("conexion cerrada");
                return true;
            }
            catch (MySqlException ex)
            {

                return false;
            }
        }

        */

    }
}