using System;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;

namespace ENTITY_FRAMEWORK_EXAMPLE.Services;

public interface ICommonService<T, TI, TU>
{
    Task<IEnumerable<T>> Get();
    Task<T> GetById(int id);
    Task<T> Add(TI objectDto);
    Task<T> Update(int id, TU objectDto);
    Task<T> Delete(int id);
}
