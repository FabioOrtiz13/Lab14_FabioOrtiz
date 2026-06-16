using Lab13_FabioOrtiz.Application.DTOs;

namespace Lab13_FabioOrtiz.Application.Ports;

public interface IReportRepository
{
    Task<List<ClientReportDto>> GetClientsReportAsync();
    Task<List<ProductReportDto>> GetProductsReportAsync();
}