using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Proyecto_INE.Models
{
    public class INEDbContext : DbContext
    {
        public INEDbContext() : base("INEDbContext")
        {

        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PartidoPolitico> PartidoPoliticos{get; set;}
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Voto> Votos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<Proyecto_INE.ViewModels.CandidatoViewModel> CandidatoViewModels { get; set; }
    }
}