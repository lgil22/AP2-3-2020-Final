using FinalProject.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.DAL;
using FinalProject.BLL;
using FinalProject.Pages;

namespace FinalProject.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cobros> Cobro { get; set; }
        public DbSet<Ventas> Venta { get; set; }
        public DbSet<Clientes> Cliente { get; set; }

        public DbSet<Usuarios> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data\VentasDB.db"); ;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios { UsuarioId = 1, Fecha = DateTime.Now, Nombres = "Luis", NombreUsuario = "Admin", Contrasena = UsuariosBLL.Encrypt("1234"), Email = "lgilbaez@gmail.com" });
        }

    }
}
