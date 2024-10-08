using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoUsuario : RepoBase<Usuario, int>, IRepoUsuario
{
    public RepoUsuario(ProyectoDbContext context) : base(context, context.Set<Usuario>())
    {
    }
}