using System.ComponentModel.DataAnnotations.Schema;

namespace bsg_crud_app.Models;

[Table("products")]
public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}