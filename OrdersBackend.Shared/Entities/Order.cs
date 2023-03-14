using OrdersBackend.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersBackend.Shared.Entities;

[Table("Orders")]
public class Order : IEntity
{
    public int Id { get; set; }
    [Required]
    public DateTime CreateDate { get; set; }
    [Required]
    public StatusEnum Status { get; set; }
    [Required]
    public string ClientName { get; set; } = string.Empty;
    [Required, Column(TypeName = "decimal(18,3)")]
    public decimal OrderPrice => OrderLines.Sum(o => o.Price);
    public string AdditionalInfo { get; set; } = string.Empty;
    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

}
