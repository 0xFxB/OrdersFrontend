using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersBackend.Shared.Entities;

[Table("OrderLines")]
public class OrderLine : IEntity
{
    public int Id { get; set; }
    [Required]
    public string Product { get; set; } = string.Empty;
    [Required, Column(TypeName = "decimal(18,3)")]
    public decimal Price { get; set; }
    [Required]
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;

}
