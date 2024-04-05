using Microsoft.EntityFrameworkCore;
using RumoRestaurantes.Models;

namespace RumoRestaurantes.Context
{
    public class PedidoContext : DbContext
    {
        
        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { 
        
        }

        public DbSet<PedidoCliente> Pedidos { get; set; }

    }
}
