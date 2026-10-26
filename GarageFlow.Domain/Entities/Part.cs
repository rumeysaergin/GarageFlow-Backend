
namespace GarageFlow.Domain.Entities;

public class Part : BaseEntity
{
    public Guid WorkshopId { get; set; }
    public Guid? PartCategoryId { get; set; }
    public Guid? SupplierId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? PartNumber { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal StockQuantity { get; set; }
    public decimal MinimumStockLevel { get; set; }
    public string? Unit { get; set; }

    public PartCategory? PartCategory { get; set; }
    public Supplier? Supplier { get; set; }
}
