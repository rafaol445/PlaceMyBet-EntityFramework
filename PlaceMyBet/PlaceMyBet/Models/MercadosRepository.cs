using Api_PlaceMyBet.Controllers;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using PlaceMyBet2.Models;

using Renci.SshNet.Messages.Transport;
using System;
using System.Collections.Generic;

using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Api_PlaceMyBet.Models
{
    public class MercadosRepository
    {
        #region Metodos
        
        internal List<Mercado> Retrive()
        {

            List<Mercado> listaMercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {

                //listaMercados = context.Mercados.Include(p => p.Evento).Select(p => p.Evento.EventoId).ToList();
                return context.Mercados.Include(p => p.Evento).ToList();
            }           
        }
        internal List<MercadoDTO> RetriveDTO() 
        {
            List<MercadoDTO> listaMercados = new List<MercadoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext()) 
            {
                listaMercados = context.Mercados.Select(p => ToDTO(p)).ToList();
            }
            return listaMercados;
        }

        static MercadoDTO ToDTO(Mercado mercado)
        {
            return new MercadoDTO(mercado.OverUnder, mercado.CuotaOver, mercado.CuotaUnder);
        }
        internal Mercado RetriveMercado(int id)
        {
            Mercado mercado;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Where(value => value.MercadoId == id).FirstOrDefault();
            }
            return mercado;
        }
        internal void GuardarMercado(Mercado mercado) {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Mercados.Add(mercado);
            context.SaveChanges();
        
        }
        internal void ActualizarMercado(int mercado, double cantidadApostada, string overUnder)
        {
            const double comision = 0.95;
            overUnder = overUnder.ToLower();
            double probabilidadOver;
            double probabilidadUnder;
            double cuotaOver = 0;
            double cuotaUnder = 0;

            Mercado mercadoDatos = RetriveMercado(mercado);

            if (overUnder == "over")
            {
                double dineroOver = mercadoDatos.DineroOver + cantidadApostada;

                probabilidadOver = calcularProbabilidad(dineroOver, mercadoDatos.DineroUnder);
                probabilidadUnder = calcularProbabilidad(mercadoDatos.DineroUnder, dineroOver);

                cuotaOver = calcularCuota(probabilidadOver, comision);
                cuotaUnder = calcularCuota(probabilidadUnder, comision);

                metodoComas();

                PlaceMyBetContext context = new PlaceMyBetContext();           
                mercadoDatos.DineroOver = dineroOver;
                mercadoDatos.CuotaOver = cuotaOver;
                mercadoDatos.CuotaUnder = cuotaUnder;
                context.Mercados.Update(mercadoDatos);
                context.SaveChanges();
            }
            else if (overUnder == "under")
            {
                double dineroUnder = mercadoDatos.DineroUnder + cantidadApostada;

                probabilidadOver = calcularProbabilidad(mercadoDatos.DineroOver, dineroUnder);
                probabilidadUnder = calcularProbabilidad(dineroUnder, mercadoDatos.DineroOver);

                cuotaOver = calcularCuota(probabilidadOver, comision);
                cuotaUnder = calcularCuota(probabilidadUnder, comision);

                metodoComas();

                PlaceMyBetContext context = new PlaceMyBetContext();                
                mercadoDatos.DineroUnder = dineroUnder;
                mercadoDatos.CuotaOver = cuotaOver;
                mercadoDatos.CuotaUnder = cuotaUnder;
                context.Mercados.Update(mercadoDatos);
                context.SaveChanges();
            }

            
        }
        internal double calcularProbabilidad(double probabilidad1, double probabilidad2)
        {
            return probabilidad1 / (probabilidad1 + probabilidad2);
        }

        internal double calcularCuota(double probabilidad, double comision)
        {

            return Math.Round((1 / probabilidad) * comision, 2, MidpointRounding.AwayFromZero);
        }
        public static void metodoComas()
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
        }

        /*
        internal List<MercadoDTO> RetriveDTO()
        {

            List<MercadoDTO> listaMercados = new List<MercadoDTO>();
            MercadoDTO mercado = new MercadoDTO();

            string consulta = string.Format("SELECT `Tipo_Over_Under`, `Cuota_Over`, `Cuota_Under` FROM `mercados`");


            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);


            DataBaseRepository.AbrirConexion();

            MySqlDataReader resultado = comand.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    mercado = new MercadoDTO(resultado.GetDouble(0), resultado.GetDouble(1), resultado.GetDouble(2));
                    listaMercados.Add(mercado);
                }
            }

            DataBaseRepository.CerrarConexion();

            return listaMercados;
        }
        */
        /*
        internal void ActualizarMercado(int mercado, double cantidadApostada, string overUnder)
        {
            const double comision = 0.95;
            overUnder = overUnder.ToLower();
            double probabilidadOver;
            double probabilidadUnder;
            double cuotaOver = 0;
            double cuotaUnder = 0;

            Mercado mercadoDatos = ObtenerMercado(mercado);

            if (overUnder == "over")
            {
                double dineroOver = mercadoDatos.dineroOver + cantidadApostada;

                probabilidadOver = calcularProbabilidad(dineroOver, mercadoDatos.dineroUnder);
                probabilidadUnder = calcularProbabilidad(mercadoDatos.dineroUnder, dineroOver);                

                cuotaOver = calcularCuota(probabilidadOver, comision);
                cuotaUnder = calcularCuota(probabilidadUnder, comision);

                metodoComas();

                string consultaUpdateOver = string.Format("UPDATE `mercados` SET `Cuota_Over` = '{0}', `Cuota_Under` = '{1}', `Dinero_Over` = '{2}', `Dinero_Under` = '{3}' WHERE `mercados`.`idMercado` = {4}; ", cuotaOver, cuotaUnder, dineroOver, mercadoDatos.dineroUnder, mercado);

                MySqlConnection conexion = DataBaseRepository.Conexion;
                MySqlCommand comand = new MySqlCommand(consultaUpdateOver, conexion);

                DataBaseRepository.AbrirConexion();

                comand.ExecuteNonQuery();

            }
            else if (overUnder == "under")
            {
                double dineroUnder = mercadoDatos.dineroUnder + cantidadApostada;

                probabilidadOver = calcularProbabilidad(mercadoDatos.dineroOver, dineroUnder);
                probabilidadUnder = calcularProbabilidad(dineroUnder, mercadoDatos.dineroOver);

                cuotaOver = calcularCuota(probabilidadOver, comision);
                cuotaUnder = calcularCuota(probabilidadUnder, comision);

                

                CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
                culInfo.NumberFormat.NumberDecimalSeparator = ".";
                culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
                culInfo.NumberFormat.PercentDecimalSeparator = ".";
                culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
                System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;


                string consultaUpdateOver = string.Format("UPDATE `mercados` SET `Cuota_Over` = '{0}', `Cuota_Under` = '{1}', `Dinero_Over` = '{2}', `Dinero_Under` = '{3}' WHERE `mercados`.`idMercado` = {4}; ", cuotaOver, cuotaUnder, mercadoDatos.dineroOver, dineroUnder, mercado);

                MySqlConnection conexion = DataBaseRepository.Conexion;
                MySqlCommand comand = new MySqlCommand(consultaUpdateOver, conexion);

                DataBaseRepository.AbrirConexion();

                comand.ExecuteNonQuery();



            }

            DataBaseRepository.CerrarConexion();
        }

        internal Mercado ObtenerMercado(int idMercado) {



            string consulta = string.Format("SELECT * FROM `mercados` WHERE idMercado = {0};", idMercado);

            Mercado mercadoDatos = new Mercado();

            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);

            DataBaseRepository.AbrirConexion();

            MySqlDataReader resultado = comand.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    mercadoDatos = new Mercado(resultado.GetInt32(0), resultado.GetDouble(1), resultado.GetDouble(2), resultado.GetDouble(3), resultado.GetDouble(4), resultado.GetDouble(5), resultado.GetInt32(6));
                }

            }
            DataBaseRepository.CerrarConexion();

            return mercadoDatos;




        }

        internal double calcularProbabilidad(double probabilidad1, double probabilidad2)
        {
            return probabilidad1 / (probabilidad1 + probabilidad2);
        }

        internal double calcularCuota(double probabilidad, double comision) {

            return Math.Round((1 / probabilidad) * comision, 2, MidpointRounding.AwayFromZero);
        }

        internal Mercado MercadosPorEvento(int idEvento, double tipo)
        {
            metodoComas();

            string consulta = string.Format("SELECT * FROM `mercados` WHERE `Tipo_Over_Under` = '{0}' AND `EVENTOS_idEvento` = '{1}' ", tipo, idEvento);

            Mercado mercadoDatos = new Mercado();

            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);

            DataBaseRepository.AbrirConexion();

            MySqlDataReader resultado = comand.ExecuteReader();

            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    mercadoDatos = new Mercado(resultado.GetInt32(0), resultado.GetDouble(1), resultado.GetDouble(2), resultado.GetDouble(3), resultado.GetDouble(4), resultado.GetDouble(5), resultado.GetInt32(6));
                }

            }
            DataBaseRepository.CerrarConexion();

            return mercadoDatos;
        }

        public static void metodoComas()
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
        }
        */
        #endregion








    }
}