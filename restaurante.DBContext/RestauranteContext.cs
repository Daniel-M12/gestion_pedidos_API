using Microsoft.EntityFrameworkCore;
using System;
using DBEntity;


namespace DBContext
{
    public class RestauranteContext: DbContext
    {
        public DbSet<Producto> productos { get; set; }

        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(producto =>
            {
                producto.ToTable("producto");
                producto.HasKey(p => p.id_producto);
                producto.Property(p => p.nombre).IsRequired().HasMaxLength(30);
                producto.Property(p => p.descripcion).IsRequired(false).HasMaxLength(100);
                producto.Property(p => p.precio).IsRequired().HasPrecision(5, 2);
                producto.Property(p => p.imagen).IsRequired().HasMaxLength(200);
                producto.Property(p => p.activo).IsRequired();

            });
        }

    }
}
