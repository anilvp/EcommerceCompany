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
    .AddTransient<IGenericRepository<Customers>, GenericRepository<Customers>>()
    .AddTransient<IGenericRepository<Deliveries>, GenericRepository<Deliveries>>()
    .AddTransient<IGenericRepository<Orders>, GenericRepository<Orders>>()
    .AddTransient<IGenericRepository<ProductOrders>, GenericRepository<ProductOrders>>()
    .AddTransient<IGenericRepository<Products>, GenericRepository<Products>>()
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