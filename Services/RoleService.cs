using System;
using AutoMapper;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using ENTITY_FRAMEWORK_EXAMPLE.Repository;
namespace ENTITY_FRAMEWORK_EXAMPLE.Services;

public class RoleService : ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>
{
    List<string> ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>.Errors => throw new NotImplementedException();

    Task<RoleDto> ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>.Add(RoleInsertDto objectDto)
    {
        throw new NotImplementedException();
    }

    Task<RoleDto> ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<RoleDto>> ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>.Get()
    {
        throw new NotImplementedException();
    }

    Task<RoleDto> ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    Task<RoleDto> ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>.Update(int id, RoleUpdateDto objectDto)
    {
        throw new NotImplementedException();
    }

    bool ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>.Validate(RoleInsertDto dto)
    {
        throw new NotImplementedException();
    }

    bool ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>.Validate(RoleUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
