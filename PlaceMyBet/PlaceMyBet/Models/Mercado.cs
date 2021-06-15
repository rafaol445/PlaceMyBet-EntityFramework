using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api_PlaceMyBet.Models
{
    public class Mercado
    {
        #region Atributos


        public int MercadoId { get; set; }
        public double OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        

        //Relaciones
        public List<Apuesta> Apuestas { get; set; }
        public int EventoId { get; set; }
        
        public Evento Evento { get; set; }

        public Mercado(int mercadoId, double overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, List<Apuesta> apuestas, int eventoId, Evento evento)
        {
            MercadoId = mercadoId;
            OverUnder = overUnder;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            
            Apuestas = apuestas;
            EventoId = eventoId;
            Evento = evento;
        }
        public Mercado()
        {
        }


        #endregion      
        
    }
    
    public class MercadoDTO
    {
        public double TipoMercado { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }

        public MercadoDTO(double tipoMercado, double cuotaOver, double cuotaUnder)
        {
            TipoMercado = tipoMercado;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
        }
        public MercadoDTO()
        {
        }
    }
    
    
        
 
}