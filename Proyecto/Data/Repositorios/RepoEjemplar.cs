using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoEjemplar : RepoBase<Ejemplar, uint>, IRepoEjemplar
{
    public RepoEjemplar(ProyectoDbContext context) : base(context, context.Set<Ejemplar>())
    {
    }
}