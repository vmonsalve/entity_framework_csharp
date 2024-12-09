using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITY_FRAMEWORK_EXAMPLE.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }
    public string correo { get; set;}
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool isAcive { get; set; }
    [ForeignKey("RoleID")]
    public virtual Role Role { get; set;}
}
