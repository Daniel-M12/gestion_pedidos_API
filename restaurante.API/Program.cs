using API;
using DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Npgsql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//var config = builder.Build();
// Load configuration from appsettings.json
//builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        name: "v1",//AppSettingsProvider.config.Version,
        new OpenApiInfo
        {
            Title = "Api",//AppSettingsProvider.config.ApplicationName,
            Version = "v1",//AppSettingsProvider.config.Version,
            Contact = new OpenApiContact()
            {
                Name = "UPC",//AppSettingsProvider.config.OrganizationName,
                Url = new System.Uri("https://www.upc.edu.pe/"),
                Email = "upc@upc.edu.pe",
            },
            Description = "",//AppSettingsProvider.config.ApplicationDescription,

            //AppSettingsProvider.config.OrganizationName
            License = new OpenApiLicense() { Name = "UPC", Url = new System.Uri("https://www.upc.edu.pe/") },
            TermsOfService = new System.Uri("https://www.upc.edu.pe/")
        });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Esta api usa Authorization  basada en JWT.-  
          Ingrese 'Bearer' [space] y luego el token de autenticación.
          Ejemplo: 'Bearer HJNX4354X...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
});

//Inyección de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RestauranteContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:5000";//AppSettingsProvider.config.UrlBaseIdentityServer;
        options.RequireHttpsMetadata = false;
        options.RefreshOnIssuerKeyNotFound = true;
        options.Audience = "API-APP-UPC";
    });

//BD PostgreSQL
//builder.Services.AddDbContext<RestauranteContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
/*var config = builder.Configuration;
var connectionString = config.GetConnectionString("Restaurante");
builder.Services.AddDbContext<RestauranteContext>(options => options.UseNpgsql(connectionString));*/
builder.Services.AddNpgsql<RestauranteContext>("Host=34.151.232.17;Port=5432;Username=postgres;Password=PostgreSQL-daniel;Database=restaurante");


// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseAuthentication();

app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

