using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_PlaceMyBet.Models
{
    public class Evento
    {
        #region Atributos
        public int EventoId { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public DateTime FechaEvento { get; set; }

        // Relaciones
        public List<Mercado> Mercados { get; set; }

        public Evento(int eventoId, string local, string visitante, DateTime fechaEvento, List<Mercado> mercados)
        {
            EventoId = eventoId;
            Local = local;
            Visitante = visitante;
            FechaEvento = fechaEvento;
            Mercados = mercados;
        }
        public Evento()
        {
        }
        #endregion
     }
}

public class EventoDto {

    public string Local { get; set; }
    public string Visitante { get; set; }

    public EventoDto(string local, string visitante)
    {
        Local = local;
        Visitante = visitante;
    }

    public EventoDto()
    {
    }
}
