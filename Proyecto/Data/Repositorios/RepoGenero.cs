using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoGenero : RepoBase<Genero, int>, IRepoGenero
{
    public RepoGenero(ProyectoDbContext context) : base(context, context.Set<Genero>())
    {
    }
}