using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoTitulo : RepoBase<Titulo, int>, IRepoTitulo
{
    public RepoTitulo(ProyectoDbContext context) : base(context, context.Set<Titulo>())
    {
    }
}