using Microsoft.EntityFrameworkCore;

namespace Reservas.Models;

public class ReserveContext : DbContext
{
    public ReserveContext(DbContextOptions<ReserveContext> options) : base(options)
    {
        
    }
    
    
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reserve> Reserves { get; set; }
}