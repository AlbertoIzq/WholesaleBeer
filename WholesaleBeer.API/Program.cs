using DotEnv.Core;
using Microsoft.EntityFrameworkCore;
using WholesaleBeer.API.Data;
using WholesaleBeer.API.Mappings;
using WholesaleBeer.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Read environment variables.
new EnvLoader().Load();
var envVarReader = new EnvReader();
string connectionString = envVarReader["DataBase_ConnectionString"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add database service.
builder.Services.AddDbContext<WholesaleBeerDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add data repositories.
builder.Services.AddScoped<IBeerRepository, SqlBeerRepository>();
builder.Services.AddScoped<IBeerStockRepository, SqlBeerStockRepository>();
builder.Services.AddScoped<IOrderDetailRepository, SqlOrderDetailRepository>();

// Add Automapper.
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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