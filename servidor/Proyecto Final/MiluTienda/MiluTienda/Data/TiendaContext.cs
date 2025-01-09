using Microsoft.EntityFrameworkCore;
using MiluTienda.Models;

namespace MiluTienda.Data
{
    public class TiendaContext : DbContext
    {
        
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Variante> Variantes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<LineaPedido> LineasPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Variante>()
                .HasOne(v => v.Producto)
                .WithMany(p => p.Variantes)
                .HasForeignKey(v => v.ProductoId);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.ClienteId);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Estado)
                .WithMany(e => e.Pedidos)
                .HasForeignKey(p => p.EstadoId);

            modelBuilder.Entity<LineaPedido>()
                .HasOne(lp => lp.Pedido)
                .WithMany(p => p.LineasPedido)
                .HasForeignKey(lp => lp.PedidoId);

            modelBuilder.Entity<LineaPedido>()
                .HasOne(lp => lp.Producto)
                .WithMany(p => p.LineasPedido)
                .HasForeignKey(lp => lp.ProductoId);
            
            modelBuilder.Entity<Producto>()
                .Property(p => p.Stock)
                .HasDefaultValue(0);
        }
    }
}
