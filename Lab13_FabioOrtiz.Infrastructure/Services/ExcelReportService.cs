using ClosedXML.Excel;
using Lab13_FabioOrtiz.Application.DTOs;
using Lab13_FabioOrtiz.Application.Ports;

namespace Lab13_FabioOrtiz.Infrastructure.Services;

public class ExcelReportService : IExcelReportService
{
    public byte[] GenerateClientsReport(List<ClientReportDto> clients)
    {
        using var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add("Clientes");

        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Cliente";
        worksheet.Cell(1, 3).Value = "Email";
        worksheet.Cell(1, 4).Value = "Total Pedidos";

        var header = worksheet.Range("A1:D1");
        header.Style.Font.Bold = true;
        header.Style.Fill.BackgroundColor = XLColor.Cyan;
        header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        var row = 2;

        foreach (var client in clients)
        {
            worksheet.Cell(row, 1).Value = client.ClientId;
            worksheet.Cell(row, 2).Value = client.ClientName;
            worksheet.Cell(row, 3).Value = client.Email;
            worksheet.Cell(row, 4).Value = client.TotalOrders;
            row++;
        }

        worksheet.Range(1, 1, row - 1, 4).CreateTable();
        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);

        return stream.ToArray();
    }

    public byte[] GenerateProductsReport(List<ProductReportDto> products)
    {
        using var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add("Productos");

        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Producto";
        worksheet.Cell(1, 3).Value = "Precio";
        worksheet.Cell(1, 4).Value = "Cantidad Vendida";
        worksheet.Cell(1, 5).Value = "Monto Total";

        var header = worksheet.Range("A1:E1");
        header.Style.Font.Bold = true;
        header.Style.Fill.BackgroundColor = XLColor.Cyan;
        header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        var row = 2;

        foreach (var product in products)
        {
            worksheet.Cell(row, 1).Value = product.ProductId;
            worksheet.Cell(row, 2).Value = product.ProductName;
            worksheet.Cell(row, 3).Value = product.Price;
            worksheet.Cell(row, 4).Value = product.TotalQuantity;
            worksheet.Cell(row, 5).Value = product.TotalAmount;
            row++;
        }

        worksheet.Range(1, 1, row - 1, 5).CreateTable();
        worksheet.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        workbook.SaveAs(stream);

        return stream.ToArray();
    }
}