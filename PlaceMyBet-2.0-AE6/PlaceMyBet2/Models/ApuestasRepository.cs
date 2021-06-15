using Api_PlaceMyBet.Controllers;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using PlaceMyBet2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Web;

namespace Api_PlaceMyBet.Models
{
    public class ApuestasRepository
    {

        #region Metodos
        
        internal List<Apuesta> Retrive() {


            List<Apuesta> listaApuestas = new List<Apuesta>();


            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                listaApuestas = context.Apuestas.Include(p => p.Mercado).ToList();
                //listaApuestas = context.Apuestas.Select(p => ToDTOconEvento(p)).ToList();
            }
            return listaApuestas;
        }

        internal Apuesta RetriveArgs(int id)
        {
            Apuesta apuesta;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas.Where(value => value.ApuestaId == id).FirstOrDefault();
            }
            return apuesta;
        }
        public static ApuestaDTO ToDTOconEvento(Apuesta apuesta)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Apuesta apuesta2 = context.Apuestas.Include(p => p.Mercado).FirstOrDefault(p => p.ApuestaId == apuesta.ApuestaId);
            ApuestaDTO apuestaDto = new ApuestaDTO(apuesta.UsuarioId, apuesta2.Mercado.EventoId, apuesta2.Mercado.OverUnder, apuesta.Cuota, apuesta.DineroApostado);
            return apuestaDto;

        }
        internal void HacerApuesta(Apuesta apuesta)
        {
            MercadosRepository mercado = new MercadosRepository();

            mercado.ActualizarMercado(apuesta.MercadoId, apuesta.DineroApostado, apuesta.TipoCuota);

            Mercado mercado2 = new Mercado();
            mercado2 = mercado.RetriveMercado(apuesta.MercadoId);

            if (apuesta.TipoCuota == "over")
            {
                PlaceMyBetContext context = new PlaceMyBetContext();
                apuesta.Cuota = mercado2.CuotaOver;
                context.Apuestas.Add(apuesta);
                context.SaveChanges();

            }
            else if (apuesta.TipoCuota == "under")
            {
                PlaceMyBetContext context = new PlaceMyBetContext();
                apuesta.Cuota = mercado2.CuotaUnder;
                context.Apuestas.Add(apuesta);
                context.SaveChanges();
            }

            

        }
        /*
        internal List<ApuestaDTO> RetriveDTO()
        {

            
            List<ApuestaDTO> listaApuestas = new List<ApuestaDTO>();
            ApuestaDTO apuesta = new ApuestaDTO();


            string consulta = string.Format("SELECT `Tipo_Cuota`, `cuota`, `Dinero_Apostado`, `fecha`, `Mercado_idMercado`, `Usuario_Email` FROM `apuestas`");

            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);


            DataBaseRepository.AbrirConexion();

            MySqlDataReader resultado = comand.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {

                    apuesta = new ApuestaDTO(resultado.GetString(0), resultado.GetDouble(1), resultado.GetDouble(2), resultado.GetDateTime(3), resultado.GetInt32(4), resultado.GetString(5));
                    listaApuestas.Add(apuesta);
                }
            }

            DataBaseRepository.CerrarConexion();

            return listaApuestas;
            


        }

       

        internal void ActualizarApuesta(double cuota, Apuesta apuesta)
        {

            string consulta = string.Format("UPDATE `apuestas` SET `cuota` = '{0}' WHERE `apuestas`.`idApuesta` = {1} AND `apuestas`.`Mercado_idMercado` = {2} AND `apuestas`.`Usuario_Email` = '{3}'; ", cuota, apuesta.idApuesta, apuesta.idMercado ,apuesta.usuarioEmail);

            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);

            DataBaseRepository.AbrirConexion();

            int retorno = comand.ExecuteNonQuery();

            if (retorno > 0)
            {

                Debug.WriteLine("consulta actualizada correctamente");
                
            }
            else { Debug.WriteLine("apuesta no realizada"); }



            DataBaseRepository.CerrarConexion();



        }

        
        internal List<ApuestaArgumentos> ApuestaPorEmailMercado(int idMercado, string email)
        {

            ApuestaArgumentos apuesta = new ApuestaArgumentos();
            List<ApuestaArgumentos> listaApuestas = new List<ApuestaArgumentos>();

            MercadosRepository.metodoComas();

            string consulta = string.Format("SELECT `mercados`.`EVENTOS_idEvento`, `apuestas`.`Tipo_Cuota`, `apuestas`.`cuota`, `apuestas`.`Dinero_Apostado` FROM `apuestas` LEFT JOIN `mercados` ON `apuestas`.`Mercado_idMercado` = `mercados`.`idMercado` ; ", email, idMercado);                

            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);

            DataBaseRepository.AbrirConexion();

            MySqlDataReader resultado = comand.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    apuesta = new ApuestaArgumentos(resultado.GetDouble(0), resultado.GetString(1), resultado.GetDouble(2), resultado.GetDouble(3));
                    listaApuestas.Add(apuesta);
                }
            }
            DataBaseRepository.CerrarConexion();

            return listaApuestas;
        }

        internal List<ApuestasPorTipoMercado> ApuestaPorEmailTipoMercado(double tipoMercado, string email)
        {

            ApuestasPorTipoMercado apuesta = new ApuestasPorTipoMercado();
            List<ApuestasPorTipoMercado> listaApuestas = new List<ApuestasPorTipoMercado>();

            MercadosRepository.metodoComas();

            string consulta = string.Format("SELECT `apuestas`.`Tipo_Cuota`, `apuestas`.`cuota`, `apuestas`.`Dinero_Apostado`, `mercados`.`EVENTOS_idEvento` FROM `apuestas` LEFT JOIN `mercados` ON `apuestas`.`Mercado_idMercado` = `mercados`.`idMercado` WHERE `mercados`.`Tipo_Over_Under` = '{0}' AND `apuestas`.`Usuario_Email` = '{1}'  ; ", tipoMercado, email);
            
            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);

            DataBaseRepository.AbrirConexion();

            MySqlDataReader resultado = comand.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    apuesta = new ApuestasPorTipoMercado(resultado.GetString(0), resultado.GetDouble(1), resultado.GetDouble(2), resultado.GetInt32(3));
                    listaApuestas.Add(apuesta);
                }

            }
            DataBaseRepository.CerrarConexion();

            return listaApuestas;




        }
        */

        #endregion

    }
}