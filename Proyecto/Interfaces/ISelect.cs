namespace Proyecto.Interfaces;

public interface ISelect<T>
{
    IQueryable<T> Select();
}
