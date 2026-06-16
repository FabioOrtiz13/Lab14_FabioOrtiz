namespace Lab13_FabioOrtiz.Application.DTOs;

public class ClientReportDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int TotalOrders { get; set; }
}