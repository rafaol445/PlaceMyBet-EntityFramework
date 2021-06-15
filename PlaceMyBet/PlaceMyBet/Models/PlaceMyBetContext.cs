using Api_PlaceMyBet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet2.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }

        public PlaceMyBetContext()
        {
        }


        public PlaceMyBetContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=127.0.0.1;Database=placemybet2;Uid=root;Pwd=''; SslMode = none");

            }
        }




    }
}