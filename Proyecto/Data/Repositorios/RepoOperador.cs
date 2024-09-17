using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoOperador : RepoBase<Operador, int>, IRepoOperador
{
    public RepoOperador(ProyectoDbContext context) : base(context, context.Set<Operador>())
    {
    }
}