// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaceMyBet2.Models;

namespace PlaceMyBet2.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    partial class PlaceMyBetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api_PlaceMyBet.Models.Apuesta", b =>
                {
                    b.Property<int>("ApuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Cuota")
                        .HasColumnType("double");

                    b.Property<double>("DineroApostado")
                        .HasColumnType("double");

                    b.Property<DateTime>("FechaApuesta")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdMercado")
                        .HasColumnType("int");

                    b.Property<int>("MercadoId")
                        .HasColumnType("int");

                    b.Property<string>("TipoCuota")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UsuarioEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("ApuestaId");

                    b.HasIndex("MercadoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Apuestas");
                });

            modelBuilder.Entity("Api_PlaceMyBet.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEvento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Local")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Visitante")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Api_PlaceMyBet.Models.Mercado", b =>
                {
                    b.Property<int>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CuotaOver")
                        .HasColumnType("double");

                    b.Property<double>("CuotaUnder")
                        .HasColumnType("double");

                    b.Property<double>("DineroOver")
                        .HasColumnType("double");

                    b.Property<double>("DineroUnder")
                        .HasColumnType("double");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("IdEvento")
                        .HasColumnType("int");

                    b.Property<double>("OverUnder")
                        .HasColumnType("double");

                    b.HasKey("MercadoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Mercados");
                });

            modelBuilder.Entity("Api_PlaceMyBet.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<bool>("Admin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PlaceMyBet2.Models.Cuenta", b =>
                {
                    b.Property<int>("CuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Banco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("DineroDisponible")
                        .HasColumnType("double");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("CuentaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("Api_PlaceMyBet.Models.Apuesta", b =>
                {
                    b.HasOne("Api_PlaceMyBet.Models.Mercado", "Mercado")
                        .WithMany("Apuestas")
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_PlaceMyBet.Models.Usuario", "Usuario")
                        .WithMany("Apuestas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Api_PlaceMyBet.Models.Mercado", b =>
                {
                    b.HasOne("Api_PlaceMyBet.Models.Evento", "Evento")
                        .WithMany("Mercados")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaceMyBet2.Models.Cuenta", b =>
                {
                    b.HasOne("Api_PlaceMyBet.Models.Usuario", "Usuario")
                        .WithOne("Cuenta")
                        .HasForeignKey("PlaceMyBet2.Models.Cuenta", "UsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
