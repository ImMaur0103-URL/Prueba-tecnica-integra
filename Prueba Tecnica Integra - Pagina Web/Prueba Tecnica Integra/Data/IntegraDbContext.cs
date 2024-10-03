using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_Integra.Models;

namespace Prueba_Tecnica_Integra.Data
{
    public class PruebaTecnicaIntegraContext : DbContext
    {
        public PruebaTecnicaIntegraContext(DbContextOptions<PruebaTecnicaIntegraContext> options)
            : base(options) { }


        public DbSet<T_PROVEEDOR> T_PROVEEDOR { get; set; }
        public DbSet<T_GRUPO_PROV> T_GRUPO_PROV { get; set; }
        public DbSet<T_ARTÍCULO> T_ARTÍCULO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_PROVEEDOR>().ToTable("T_PROVEEDOR");
            modelBuilder.Entity<T_GRUPO_PROV>().ToTable("T_GRUPO_PROV");
            modelBuilder.Entity<T_ARTÍCULO>().ToTable("T_ARTÍCULO");

            modelBuilder.Entity<T_ARTÍCULO>()
                .Property(a => a.Precio)
                .HasPrecision(18, 2);

            modelBuilder.Entity<T_ARTÍCULO>()
                .Property(a => a.Stock)
                .HasPrecision(18, 2);

            modelBuilder.Entity<T_PROVEEDOR>()
                .HasOne(p => p.GrupoProveedor)
                .WithMany(g => g.Proveedores)
                .HasForeignKey(p => p.IDGrupoProv);

            modelBuilder.Entity<T_ARTÍCULO>()
                .HasOne(a => a.Proveedor)
                .WithMany(p => p.Articulos)
                .HasForeignKey(a => a.IDProveedor);
        }
    }
}