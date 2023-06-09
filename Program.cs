using Microsoft.EntityFrameworkCore;
using Api2.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Itemcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Itemcontext") ?? throw new InvalidOperationException("Connection string 'Itemcontext' not found.")));

builder.Services.AddControllers();
builder.Services.AddDbContext<ItemContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();