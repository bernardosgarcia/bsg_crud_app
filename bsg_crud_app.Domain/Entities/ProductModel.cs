using System.ComponentModel.DataAnnotations.Schema;

namespace bsg_crud_app.Domain.Entities;

[Table("products")]
public class ProductEntity : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}