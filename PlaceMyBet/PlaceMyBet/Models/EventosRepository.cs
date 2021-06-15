using Api_PlaceMyBet.Controllers;
using MySql.Data.MySqlClient;
using PlaceMyBet2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_PlaceMyBet.Models
{
    public class EventosRepository
    {
        #region Metodos
        
        internal List<Evento> Retrive()
        {


            List<Evento> listaEventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                listaEventos = context.Eventos.ToList();
            }
            return listaEventos;
            
        }
        internal List<EventoDto> RetriveDTO() 
        {
            List<EventoDto> listaEventos = new List<EventoDto>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                listaEventos = context.Eventos.Select(p => ToDto(p)).ToList();
            }
            return listaEventos;

        }
        static EventoDto ToDto(Evento evento) {
            return new EventoDto(evento.Local, evento.Visitante);
        }
        internal Evento RetriveEvento(int id)
        {
            Evento evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos.Where(value => value.EventoId == id).FirstOrDefault();
            }
            return evento;
        }

        internal void GuardarEvento(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(evento);
            context.SaveChanges();
        }
        internal void ActualizarEvento(Evento evento) 
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Update(evento);
            context.SaveChanges();
        }
        internal void RemoveEvento(int id) 
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Evento evento = RetriveEvento(id);
            context.Remove(evento);
            context.SaveChanges();


        }
        /*
        internal List<EventoDto> RetriveDTO()
        {

            List<EventoDto> listaEventos = new List<EventoDto>();
            
            EventoDto evento = new EventoDto();


            string consulta = string.Format("SELECT `local`, `visitante`, `fecha` FROM `eventos`");

            MySqlConnection conexion = DataBaseRepository.Conexion;
            MySqlCommand comand = new MySqlCommand(consulta, conexion);


            DataBaseRepository.AbrirConexion();
            try
            {
                MySqlDataReader resultado = comand.ExecuteReader();

                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        evento = new EventoDto(resultado.GetString(0), resultado.GetString(1), resultado.GetDateTime(2));
                        listaEventos.Add(evento);
                    }
                }

                DataBaseRepository.CerrarConexion();


            }
            catch (Exception)
            {


            }




            return listaEventos;
        }

        */
        

        



        #endregion


    }
}