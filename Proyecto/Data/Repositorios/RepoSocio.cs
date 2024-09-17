using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Data.Repositorios;

public class RepoSocio : RepoBase<Socio, int>, IRepoSocio
{
    public RepoSocio(ProyectoDbContext context) : base(context, context.Set<Socio>())
    {
    }
}