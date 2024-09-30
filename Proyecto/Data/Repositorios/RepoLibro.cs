using Proyecto.Interfaces;
using Proyecto.Models;
using Proyecto.Interfaces;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace Proyecto.Data.Repositorios;

public class RepoLibro : RepoBase<Libro, int>, IRepoLibro
{
    public RepoLibro(ProyectoDbContext context) : base(context, context.Set<Libro>())
    {
    }
}
