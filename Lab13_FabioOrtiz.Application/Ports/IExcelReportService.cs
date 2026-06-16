using Lab13_FabioOrtiz.Application.DTOs;

namespace Lab13_FabioOrtiz.Application.Ports;

public interface IExcelReportService
{
    byte[] GenerateClientsReport(List<ClientReportDto> clients);
    byte[] GenerateProductsReport(List<ProductReportDto> products);
}