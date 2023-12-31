using Microsoft.EntityFrameworkCore;
using Restoran_API;
using Restoran_API.Models;
using Restoran_API.Repository;
using Restoran_API.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<dbRestoranMakananContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbConn")
));

// dependency injection
builder.Services.AddScoped<IJabatanRepository, JabatanRepository>();
builder.Services.AddScoped<IPenggunaRepository, PenggunaRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IPesananRepository, PesananRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

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
