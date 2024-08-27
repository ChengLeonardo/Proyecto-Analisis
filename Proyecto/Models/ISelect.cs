namespace Proyecto.Models;

public interface ISelect<T>
{
    List<T> Select();
}
