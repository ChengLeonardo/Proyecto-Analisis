namespace Proyecto.Interfaces;

public interface IRepoBase<T, N> : ISelect<T>, IIdSelect<T, N>, IUpdate<T>, IDelete<T>, IInsert<T, N>
{
}
