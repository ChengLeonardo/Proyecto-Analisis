using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoEditorial : RepoBase<Editorial, int>, IRepoEditorial
{
    public RepoEditorial(ProyectoDbContext context) : base(context, context.Set<Editorial>())
    {
    }
}