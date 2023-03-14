using Microsoft.EntityFrameworkCore;
using OrdersBackend.Shared.Entities;

namespace OrdersBackend.Data;

public class OrdersDbContext : DbContext
{
	public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }

	public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
	{
        Database.Migrate();
    }
}
