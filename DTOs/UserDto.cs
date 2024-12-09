using System;

namespace ENTITY_FRAMEWORK_EXAMPLE.DTOs;

public class UserDto
{
    public string correo { get; set; }
    public byte[] password { get; set; }
    public int RoleId { get; set; }
}
