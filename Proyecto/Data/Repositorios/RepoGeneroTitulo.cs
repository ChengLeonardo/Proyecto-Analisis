using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoGeneroTitulo : RepoBase<GeneroTitulo, int>, IRepoGeneroTitulo
{
    public RepoGeneroTitulo(ProyectoDbContext context) : base(context, context.Set<GeneroTitulo>())
    {
    }
}
