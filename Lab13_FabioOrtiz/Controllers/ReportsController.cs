using Lab13_FabioOrtiz.Application.UseCases.Reports.GenerateClientsReport;
using Lab13_FabioOrtiz.Application.UseCases.Reports.GenerateProductsReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_FabioOrtiz.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("clients")]
    public async Task<IActionResult> GenerateClientsReport()
    {
        var file = await _mediator.Send(new GenerateClientsReportQuery());

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "reporte_clientes.xlsx");
    }

    [HttpGet("products")]
    public async Task<IActionResult> GenerateProductsReport()
    {
        var file = await _mediator.Send(new GenerateProductsReportQuery());

        return File(
            file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "reporte_productos.xlsx");
    }
}