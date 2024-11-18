using System;

namespace ENTITY_FRAMEWORK_EXAMPLE.DTOs;

public class BeerUpdateDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int BrandID { get; set; }
    public decimal Alcohol { get; set; }
}
