using Lab13_FabioOrtiz.Application.DTOs;
using Lab13_FabioOrtiz.Application.Ports;
using Lab13_FabioOrtiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab13_FabioOrtiz.Infrastructure.Persistence;

public class ReportRepository : IReportRepository
{
    private readonly AppDbContext _context;

    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ClientReportDto>> GetClientsReportAsync()
    {
        return await _context.Clients
            .Select(c => new ClientReportDto
            {
                ClientId = c.Clientid,
                ClientName = c.Name,
                Email = c.Email,
                TotalOrders = c.Orders.Count
            })
            .ToListAsync();
    }

    public async Task<List<ProductReportDto>> GetProductsReportAsync()
    {
        return await _context.Products
            .Select(p => new ProductReportDto
            {
                ProductId = p.Productid,
                ProductName = p.Name,
                Price = p.Price,
                TotalQuantity = p.Orderdetails.Sum(od => od.Quantity),
                TotalAmount = p.Orderdetails.Sum(od => od.Quantity * p.Price)
            })
            .ToListAsync();
    }
}