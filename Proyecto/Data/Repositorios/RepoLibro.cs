using Proyecto.Interfaces;
using Proyecto.Models;
using Proyecto.Interfaces;

namespace Proyecto.Data.Repositorios;

public class RepoLibro : RepoBase<Libro, int>, IRepoLibro
{
    public RepoLibro(ProyectoDbContext context) : base(context, context.Set<Libro>())
    {
    }
}
