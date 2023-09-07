using Application.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Domain;
using Dtos;

namespace Application;

public class OrderCreator : ICreateOrders
{
    private readonly IUnitOfWork _uow;
    private readonly IGenericRepository<Customers> _customersRepo;
    private readonly IGenericRepository<Orders> _ordersRepo;

    public OrderCreator(IUnitOfWork uow, IGenericRepository<Customers> customersRepo, IGenericRepository<Orders> ordersRepo)
    {
        _uow = uow;
        _customersRepo = customersRepo;
        _ordersRepo = ordersRepo;
    }

    public void Add(OrderDto orderDto)
    {
        var customer = _customersRepo.GetById(orderDto.CustomerId);
        if (customer == null)
        {
            customer = new Customers(orderDto.CustomerName);
            _customersRepo.Insert(customer);
        }
        List<ProductOrders> productOrders = new List<ProductOrders>();
        foreach (var productOrderDto in orderDto.ProductOrders)
        {
            ProductOrders productOrder = new ProductOrders(productOrderDto.ProductId, productOrderDto.Price, productOrderDto.Quantity);
            productOrders.Add(productOrder);
        }
        var order = customer.CreateOrder(orderDto.CustomerId, orderDto.Address, productOrders);
        _ordersRepo.Insert(order);
        _uow.Save();
    }
}