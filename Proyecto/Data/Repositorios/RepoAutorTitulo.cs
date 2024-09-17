using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoAutorTitulo : RepoBase<AutorTitulo, int>, IRepoAutorTitulo
{
    public RepoAutorTitulo(ProyectoDbContext context) : base(context, context.Set<AutorTitulo>())
    {
    }
}