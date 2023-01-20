using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiCoreWithEF.Context;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CompanyContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ByDefault")));
//builder.Services.Configure<CompanyContext>(options =>
// {
//     options.UseSqlServer.Seed();
//    });
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
