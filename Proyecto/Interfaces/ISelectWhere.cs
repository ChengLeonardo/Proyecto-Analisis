using System.Linq.Expressions;

namespace Proyecto.Interfaces;

public interface ISelectWhere<T>
{
    IQueryable<T> SelectWhere(Expression<Func<T, bool>> predicate);
}
