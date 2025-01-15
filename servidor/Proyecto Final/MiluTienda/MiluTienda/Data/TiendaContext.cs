using Microsoft.EntityFrameworkCore;
using MiluTienda.Models;

namespace MiluTienda.Data
{
    public class TiendaContext : DbContext
    {
        
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

    // DbSet para cada una de las entidades
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<LineaPedido> LineasPedido { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }

    // Configuración de relaciones (puedes personalizar estas relaciones si es necesario)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar relaciones y restricciones adicionales si es necesario


        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Productos)
            .HasForeignKey(p => p.CategoriaId)
            .OnDelete(DeleteBehavior.NoAction);

            // Relación uno a muchos entre Pedido y LineaPedido
            modelBuilder.Entity<LineaPedido>()
            .HasOne(lp => lp.Pedido)
            .WithMany(p => p.LineasPedido)
            .HasForeignKey(lp => lp.PedidoId);

        // Relación uno a muchos entre FamiliaProducto y LineaPedido
        modelBuilder.Entity<LineaPedido>()
            .HasOne(lp => lp.Producto)
            .WithMany(fp => fp.LineasPedido)
            .HasForeignKey(lp => lp.ProductoId);

        // Relación uno a muchos entre Cliente y Pedido
        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId);

        // Relación uno a muchos entre Estado y Pedido
        modelBuilder.Entity<Pedido>()
            .HasOne(p => p.Estado)
            .WithMany(e => e.Pedidos)
            .HasForeignKey(p => p.EstadoId);
    }
    }
}
