using Microsoft.EntityFrameworkCore;
using System;
using DBEntity;
using System.Threading;


namespace DBContext
{
    public class RestauranteContext: DbContext
    {
        public DbSet<Producto> productos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Mesa> mesas { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<EntityUser> users { get; set; }
        

        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(producto =>
            {
                producto.ToTable("producto");
                producto.HasKey(p => p.id_producto);
                producto.Property(p => p.nombre).IsRequired().HasMaxLength(30);
                producto.Property(p => p.descripcion).IsRequired(false).HasMaxLength(150);
                producto.Property(p => p.precio).IsRequired().HasPrecision(5, 2);
                producto.Property(p => p.imagen).IsRequired().HasMaxLength(200);
                producto.Property(p => p.categoria).IsRequired();
                producto.Property(p => p.atendido).IsRequired().HasDefaultValue(false);
                producto.Property(p => p.cantidad).IsRequired().HasDefaultValue(0);
                //producto.HasOne<Categoria>(p => p.categoria_detalle).WithMany(p => p.productos).HasForeignKey(p => p.categoria);
                
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("categoria");
                categoria.HasKey(c => c.id_categoria);
                categoria.Property(c => c.nombre).IsRequired().HasMaxLength(25);
                categoria.Property(c => c.descripcion).IsRequired(false).HasMaxLength(150);              
            });

            modelBuilder.Entity<Mesa>(mesa =>
            {
                mesa.ToTable("mesa");
                mesa.HasKey(m => m.id_mesa);
                mesa.Property(m => m.nombre).IsRequired().HasMaxLength(25);
                mesa.Property(m => m.ocupada).IsRequired();
            });

            modelBuilder.Entity<Pedido>(pedido =>
            {
                pedido.ToTable("pedido");
                pedido.HasKey(p => p.id_pedido);
                pedido.Property(p => p.fecha).IsRequired();
                pedido.Property(p => p.atendido).IsRequired();
            });

            modelBuilder.Entity<EntityUser>(usuario =>
            {
                usuario.ToTable("usuario");
                usuario.HasKey(u => u.id_usuario);
                usuario.Property(u => u.login_usuario).IsRequired().HasMaxLength(25);
                usuario.Property(u => u.password).IsRequired();
                usuario.Property(u => u.rol).IsRequired().HasMaxLength(25);
                usuario.Property(u => u.dni).IsRequired().HasMaxLength(8);
            });
        }

    }
}
