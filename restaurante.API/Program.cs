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
builder.Services.AddScoped<RestauranteContext>();

//BD PostgreSQL
//builder.Services.AddDbContext<RestauranteContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
/*var config = builder.Configuration;
var connectionString = config.GetConnectionString("Restaurante");
builder.Services.AddDbContext<RestauranteContext>(options => options.UseNpgsql(connectionString));*/
builder.Services.AddNpgsql<RestauranteContext>("Host=34.151.232.17;Port=5432;Username=postgres;Password=PostgreSQL-daniel;Database=restaurante");

var app = builder.Build();

app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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

