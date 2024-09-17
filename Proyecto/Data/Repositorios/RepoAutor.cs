using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoAutor : RepoBase<Autor, int>, IRepoAutor
{
    public RepoAutor(ProyectoDbContext context) : base(context, context.Set<Autor>())
    {
    }
}