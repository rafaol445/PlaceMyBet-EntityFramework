using PlaceMyBet2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_PlaceMyBet.Models
{
    public class Usuario
    {
        #region Atributos
        // Campos 
        public string UsuarioId { get; set; }
        public string Nombre { get; set; }        
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public bool Admin { get; set; }

        // Relaciones
        public Cuenta Cuenta { get; set; }
        public List<Apuesta> Apuestas { get; set; }

        public Usuario(string usuarioId, string nombre, string apellidos, int edad, bool admin, Cuenta cuenta, List<Apuesta> apuestas)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Admin = admin;
            Cuenta = cuenta;
            Apuestas = apuestas;
        }
        public Usuario()
        {

        }

        #endregion

       
    }
}