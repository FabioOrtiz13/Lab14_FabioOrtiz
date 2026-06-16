namespace Lab13_FabioOrtiz.Application.DTOs;

public class ProductReportDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int TotalQuantity { get; set; }
    public decimal TotalAmount { get; set; }
}