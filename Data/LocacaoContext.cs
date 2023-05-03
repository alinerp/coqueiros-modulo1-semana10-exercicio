using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using locadoraDeCarros.Models;
using locadoraDeCarros.Data.Mappings;



namespace locadoraDeCarros.Data
{
    public class LocacaoContext : DbContext
    {
        public LocacaoContext(DbContextOptions<LocacaoContext> options) : base(options) { }

        public DbSet<MarcaModel> Marcas { get; set; }

        public DbSet<CarroModel> Carros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarroMap());

            modelBuilder.ApplyConfiguration(new MarcaMap());

        }
    }




}