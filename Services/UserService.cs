using System;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;

namespace ENTITY_FRAMEWORK_EXAMPLE.Services;

public class UserService : ICommonService<UserDto, UserInsertDto, UserUpdateDto>
{
    List<string> ICommonService<UserDto, UserInsertDto, UserUpdateDto>.Errors => throw new NotImplementedException();

    Task<UserDto> ICommonService<UserDto, UserInsertDto, UserUpdateDto>.Add(UserInsertDto objectDto)
    {
        throw new NotImplementedException();
    }

    Task<UserDto> ICommonService<UserDto, UserInsertDto, UserUpdateDto>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<UserDto>> ICommonService<UserDto, UserInsertDto, UserUpdateDto>.Get()
    {
        throw new NotImplementedException();
    }

    Task<UserDto> ICommonService<UserDto, UserInsertDto, UserUpdateDto>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    Task<UserDto> ICommonService<UserDto, UserInsertDto, UserUpdateDto>.Update(int id, UserUpdateDto objectDto)
    {
        throw new NotImplementedException();
    }

    bool ICommonService<UserDto, UserInsertDto, UserUpdateDto>.Validate(UserInsertDto dto)
    {
        throw new NotImplementedException();
    }

    bool ICommonService<UserDto, UserInsertDto, UserUpdateDto>.Validate(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
