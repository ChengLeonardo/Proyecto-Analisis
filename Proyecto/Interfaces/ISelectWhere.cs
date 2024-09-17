using System.Linq.Expressions;

namespace Proyecto.Interfaces;

public interface ISelectWhere<T>
{
    List<T> SelectWhere(Expression<Func<T, bool>> predicate);
}
