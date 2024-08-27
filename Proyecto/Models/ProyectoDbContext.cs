using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models;

public class ProyectoDbContext : DbContext
{
    public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options)
    {
    }
}
