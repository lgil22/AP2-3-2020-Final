using FinalProject.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cobros> Cobro { get; set; }
        public DbSet<Ventas> Venta { get; set; }

        public DbSet<Clientes> Cliente { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data\Ventas.db"); ;

        }

    }
}
