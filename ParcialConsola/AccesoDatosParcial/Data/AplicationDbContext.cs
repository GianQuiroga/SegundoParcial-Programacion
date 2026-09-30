using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatosParcial.Models;

namespace AccesoDatosParcial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Cancion> Canciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\databases\\BaseDatosParcial.db");
        }
    }
}
