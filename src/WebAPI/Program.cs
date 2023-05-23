using Aplication;
using Domain.Interface.Repository;
using Infra.Context;
using Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Domain.Interface.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DataBase");

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
             builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .Build();
    });
});

builder.Services.AddControllers();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<IPostoDeGasolinaAppService, PostoDeGasolinaAPPService>();
builder.Services.AddScoped<IPostoDeGasolinaRepository, PostoDeGasolinaRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("EnableCORS");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
