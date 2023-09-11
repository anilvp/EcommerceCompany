using Microsoft.AspNetCore.Builder;
using DataAccess.Repositories;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connstr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddDbContext<ECommerceCompanyContext>(options => options.UseSqlServer(connstr));
builder.Services.AddScoped<DbContext, ECommerceCompanyContext>()
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddTransient<IGenericRepository<Customer>, GenericRepository<Customer>>()
    .AddTransient<IGenericRepository<Delivery>, GenericRepository<Delivery>>()
    .AddTransient<IGenericRepository<Order>, GenericRepository<Order>>()
    .AddTransient<IGenericRepository<ProductOrder>, GenericRepository<ProductOrder>>()
    .AddTransient<IGenericRepository<Product>, GenericRepository<Product>>()
    .AddTransient<ICreateOrders, OrderCreator>()
    .AddTransient<IFindOrders, OrderFinder>();


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();