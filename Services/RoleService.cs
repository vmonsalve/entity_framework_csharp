using System;
using AutoMapper;
using ENTITY_FRAMEWORK_EXAMPLE.DTOs;
using ENTITY_FRAMEWORK_EXAMPLE.Models;
using ENTITY_FRAMEWORK_EXAMPLE.Repository;
namespace ENTITY_FRAMEWORK_EXAMPLE.Services;

public class RoleService  : ICommonService<RoleDto, RoleInsertDto, RoleUpdateDto>
{

}
