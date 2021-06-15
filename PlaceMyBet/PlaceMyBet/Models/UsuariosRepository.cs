using Api_PlaceMyBet.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Api_PlaceMyBet.Models
{
    public class UsuariosRepository
    {
        
        #region Metodos
        /// <summary>
        /// Merodo que devuelve una lista de Usuarios cargada desde la base de datos
        /// </summary>
        /// <returns> Array cargado con los usuarios </returns>
        /*
        internal List<Usuario> Retrive()
        {
            // Lista y variable donde se cargaran los usuarios
            List<Usuario> listaUsuarios = new List<Usuario>();
            Usuario user = new Usuario();            

            string consulta = string.Format("SELECT * FROM `usuarios`");

            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);

            DataBaseRepository.AbrirConexion();            
            
            MySqlDataReader resultado = comand.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    user = new Usuario(resultado.GetString(0), resultado.GetString(1), resultado.GetString(2), resultado.GetInt32(3), resultado.GetBoolean(4));
                    listaUsuarios.Add(user);
                }
            }
            
            DataBaseRepository.CerrarConexion();

            return listaUsuarios;            
        }
        */
        #endregion

    }
}