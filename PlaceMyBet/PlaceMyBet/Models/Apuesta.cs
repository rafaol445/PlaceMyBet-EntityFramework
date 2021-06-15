using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_PlaceMyBet.Models
{
    public class Apuesta
    {
        #region Atributos
        public int ApuestaId { get; set; }
        public string TipoCuota { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public DateTime FechaApuesta { get; set; }
        

        // Relaciones
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int MercadoId { get; set; }
        public Mercado Mercado { get; set; }

        public Apuesta(int apuestaId, string tipoCuota, double cuota, double dineroApostado, DateTime fechaApuesta, string usuarioId, Usuario usuario, int mercadoId, Mercado mercado)
        {
            ApuestaId = apuestaId;
            TipoCuota = tipoCuota;
            Cuota = cuota;
            DineroApostado = dineroApostado;
            FechaApuesta = fechaApuesta;
            UsuarioId = usuarioId;
            Usuario = usuario;
            MercadoId = mercadoId;
            Mercado = mercado;
        }

        public Apuesta()
        {
        }
        #endregion
    }
    
    public class ApuestaDTO
    {

        public string EmailId  { get; set; }
        public int EventoId  { get; set; }
        public double TipoApuesta  { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }

        public ApuestaDTO(string emailId, int eventoId, double tipoApuesta, double cuota, double dineroApostado)
        {
            EmailId = emailId;
            EventoId = eventoId;
            TipoApuesta = tipoApuesta;
            Cuota = cuota;
            DineroApostado = dineroApostado;
        }

        

        public ApuestaDTO()
        {
        }
    }/*
    
    #region Clase Apuesta Argumentos       

    public class ApuestaArgumentos
    {
        public double tipoMercado;
        public string tipoApuesta;
        public double cuota;
        public double dineroApostado;

        public ApuestaArgumentos(double tipoMercado, string tipoApuesta, double cuota, double dineroApostado)
        {
            this.tipoMercado = tipoMercado;
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
        }
        public ApuestaArgumentos()
        {
        }
    }

    public class ApuestasPorTipoMercado
    {
        
        public string tipoApuesta;
        public double cuota;
        public double dineroApostado;
        public int tipoEvento;

        public ApuestasPorTipoMercado(string tipoApuesta, double cuota, double dineroApostado, int tipoEvento)
        {
            this.tipoApuesta = tipoApuesta;
            this.cuota = cuota;
            this.dineroApostado = dineroApostado;
            this.tipoEvento = tipoEvento;
        }

        public ApuestasPorTipoMercado()
        {
        }
    }        
    #endregion
    */
}