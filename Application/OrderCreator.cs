using Application.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Domain;
using Dtos;

namespace Application;

public class OrderCreator : ICreateOrders
{
    private readonly IUnitOfWork _uow;
    private readonly IGenericRepository<Customer> _customersRepo;

    public OrderCreator(IUnitOfWork uow, IGenericRepository<Customer> customersRepo)
    {
        _uow = uow;
        _customersRepo = customersRepo;
    }

    public void Add(OrderDto orderDto)
    {
        var customer = _customersRepo.GetById(orderDto.CustomerId);
        if (customer == null)
        {
            customer = new Customer(orderDto.CustomerName);
            _customersRepo.Insert(customer);
        }
        List<ProductOrder> productOrders = new List<ProductOrder>();
        foreach (var productOrderDto in orderDto.ProductOrders)
        {
            ProductOrder productOrder = new ProductOrder(productOrderDto.ProductId, productOrderDto.Price, productOrderDto.Quantity);
            productOrders.Add(productOrder);
        }
        /*var order = */customer.CreateOrder(/*orderDto.CustomerId,*/ orderDto.Address, productOrders);
        //_ordersRepo.Insert(order); DON'T NEED THIS LINE
        _uow.Save();
    }
}