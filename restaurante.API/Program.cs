using DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

//BD PostgreSQL
//builder.Services.AddDbContext<RestauranteContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddNpgsql<RestauranteContext>("Host=localhost;Port=5433;Username=postgres;Password=postgres;Database=restaurante");

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

