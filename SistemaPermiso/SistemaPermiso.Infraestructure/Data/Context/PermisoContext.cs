using Microsoft.EntityFrameworkCore;
using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Infraestructure.Data.Context
{
    //DbContextConnections
   public class PermmisionContext : DbContext
    {
        public PermmisionContext()
        {

        }

        public PermmisionContext(DbContextOptions<PermmisionContext> options): base(options) { }
       
        public DbSet<Permmisions> Permmisions { get; set; }
        public DbSet<PermmisionsType> PermmisionsTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //apply assembly fluent api
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
