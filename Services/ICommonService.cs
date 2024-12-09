using System;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;

namespace ENTITY_FRAMEWORK_EXAMPLE.Services;

public interface ICommonService<T, TI, TU>
{
    public List<string> Errors { get; }
    Task<IEnumerable<T>> Get();
    Task<T> GetById(int id);
    Task<T> Add(TI objectDto);
    Task<T> Update(int id, TU objectDto);
    Task<T> Delete(int id);
    bool Validate(TI dto);
    bool Validate(TU dto);
}
