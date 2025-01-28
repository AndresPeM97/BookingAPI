using Reservas.Models;

namespace Reservas.Services;

public interface ICommonService <T, TI, TU>
{
    Task<IEnumerable<T>> Get();
    Task<T> GetById(int id);
    Task<T> Add(TI TIentityInsertDto);
    Task<T> Update(TU TUentityUpdateDto);
    Task<T> Delete(int id);
}