namespace Proyecto.Interfaces;

public interface IIdSelect<T, N>
{
    T? IdSelect(N id);
}