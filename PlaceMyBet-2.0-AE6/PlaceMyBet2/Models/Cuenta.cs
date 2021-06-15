using Api_PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet2.Models
{
    public class Cuenta
    {

        public int CuentaId { get; set; }
        public string Banco { get; set; }
        public double DineroDisponible{ get; set; }

        // Relaciones
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cuenta(int cuentaId, string banco, double dineroDisponible, string usuarioId, Usuario usuario)
        {
            CuentaId = cuentaId;
            Banco = banco;
            DineroDisponible = dineroDisponible;
            UsuarioId = usuarioId;
            Usuario = usuario;
        }

        public Cuenta()
        {
        }
    }
}