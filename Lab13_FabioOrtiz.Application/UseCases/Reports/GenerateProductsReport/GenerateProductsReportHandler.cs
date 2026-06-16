using Lab13_FabioOrtiz.Application.Ports;
using MediatR;

namespace Lab13_FabioOrtiz.Application.UseCases.Reports.GenerateProductsReport;

public class GenerateProductsReportHandler : IRequestHandler<GenerateProductsReportQuery, byte[]>
{
    private readonly IReportRepository _reportRepository;
    private readonly IExcelReportService _excelReportService;

    public GenerateProductsReportHandler(
        IReportRepository reportRepository,
        IExcelReportService excelReportService)
    {
        _reportRepository = reportRepository;
        _excelReportService = excelReportService;
    }

    public async Task<byte[]> Handle(
        GenerateProductsReportQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _reportRepository.GetProductsReportAsync();

        return _excelReportService.GenerateProductsReport(products);
    }
}