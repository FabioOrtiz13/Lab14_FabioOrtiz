using Lab13_FabioOrtiz.Application.Ports;
using Lab13_FabioOrtiz.Application.UseCases.Reports.GenerateClientsReport;
using Lab13_FabioOrtiz.Infrastructure.Data;
using Lab13_FabioOrtiz.Infrastructure.Persistence;
using Lab13_FabioOrtiz.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IExcelReportService, ExcelReportService>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GenerateClientsReportQuery).Assembly));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();