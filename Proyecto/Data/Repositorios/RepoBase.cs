using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Proyecto.Interfaces;

namespace Proyecto.Models;

public class RepoBase<T, N> : IRepoBase<T, N> where T : class
{
    protected readonly DbSet<T> _dbSet;
    protected ProyectoDbContext _context;

    public RepoBase(ProyectoDbContext context, DbSet<T> dbSet)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Delete(T objeto)
    {
        _dbSet.Remove(objeto);
        _context.SaveChanges();
    }

    public T? IdSelect(N id)
    {
        var resultado = _dbSet.Find(id);
        return resultado;
    }

    public N Insert(T objeto, string keyPropertyName)
    {
        _dbSet.Add(objeto);
        _context.SaveChanges();

        var keyProperty = _context.Entry(objeto).Property(keyPropertyName).CurrentValue;
        return (N)keyProperty;
    }

    public List<T> Select()
    {
        return _dbSet.ToList();
    }
    public List<T> SelectWhere(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }

    public void Update(T objeto)
    {
        _dbSet.Update(objeto);
        _context.SaveChanges();
    }
}