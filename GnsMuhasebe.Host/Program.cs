using GnsMuhasebe.Application;
using GnsMuhasebe.Infrastructure;
using GnsMuhasebe.Infrastructure.Persistance;
using Güneþ_Muhasebe.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddLocalization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfraStructureServices();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString,b => b.MigrationsAssembly("GnsMuhasebe.Infrastructure")));

var app = builder.Build();

var supportedLanguages = new[] { "tr-TR", "en-EN" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("tr-TR")
    .AddSupportedCultures(supportedLanguages)
    .AddSupportedUICultures(supportedLanguages);

app.UseRequestLocalization(localizationOptions);

app.UseMiddleware<GlobalExceptionMiddleware>();
    

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
