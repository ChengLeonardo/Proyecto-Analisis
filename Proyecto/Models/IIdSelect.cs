namespace Proyecto.Models;

public interface IIdSelect<T, N>
{
    T? IdSelect(N id);
}