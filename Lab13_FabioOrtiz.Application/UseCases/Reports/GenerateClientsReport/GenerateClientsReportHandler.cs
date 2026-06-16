using Lab13_FabioOrtiz.Application.Ports;
using MediatR;

namespace Lab13_FabioOrtiz.Application.UseCases.Reports.GenerateClientsReport;

public class GenerateClientsReportHandler : IRequestHandler<GenerateClientsReportQuery, byte[]>
{
    private readonly IReportRepository _reportRepository;
    private readonly IExcelReportService _excelReportService;

    public GenerateClientsReportHandler(
        IReportRepository reportRepository,
        IExcelReportService excelReportService)
    {
        _reportRepository = reportRepository;
        _excelReportService = excelReportService;
    }

    public async Task<byte[]> Handle(
        GenerateClientsReportQuery request,
        CancellationToken cancellationToken)
    {
        var clients = await _reportRepository.GetClientsReportAsync();

        return _excelReportService.GenerateClientsReport(clients);
    }
}