using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTITY_FRAMEWORK_EXAMPLE.Models;

public class Brand
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BrandID { get; set; }
    public required string Nombre { get; set; }
}
