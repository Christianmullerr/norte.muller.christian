using HardwarePC.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Services
{
    //DbContext generalmente representa una conexión de base de datos y un conjunto de tablas. 
    public partial class HardwarePcDbContext : DbContext
    {
        public HardwarePcDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<HardwarePcDbContext>(null);
        }
        /// <summary>
        /// PluralizingTableNameConvention
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        /// DbSet Artist se utiliza para representar una tabla.
        public virtual DbSet<Marca> Marca { get; set; }

        /// DbSet Product se utiliza para representar una tabla.
        public virtual DbSet<Producto> Producto { get; set; }

        /// DbSet Product se utiliza para representar una tabla.
        public virtual DbSet<Error> Error { get; set; }

    }
}
