using MediatR;
using Microsoft.EntityFrameworkCore;
using ExemploApi.Domain.Repositories;
using ExemploApi.Infra.Context;
using ExemploApi.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors-oneplace", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ExampleDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseAdmin")));

builder.Services.AddScoped<IExampleRepository, ExampleRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mediatr
builder.Services.AddMediatR(
    AppDomain.CurrentDomain.Load("ExemploApi.Api"),
    AppDomain.CurrentDomain.Load("ExemploApi.Domain"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("cors-oneplace");

app.UseAuthorization();

app.MapControllers();

app.Run();
