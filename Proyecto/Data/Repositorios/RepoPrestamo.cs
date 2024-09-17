using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoPrestamo : RepoBase<Prestamo, int>, IRepoPrestamo
{
    public RepoPrestamo(ProyectoDbContext context) : base(context, context.Set<Prestamo>())
    {
    }
}