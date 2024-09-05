namespace Proyecto.Interfaces;

public interface IInsert<T, N>
{
    N Insert(T objeto, string idAutoIncrement);
}