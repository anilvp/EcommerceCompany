using Application.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Domain;
using Dtos;

namespace Application;

public class OrderFinder : IFindOrders
{
    private readonly IUnitOfWork _uow;
    private readonly IGenericRepository<Orders> _ordersRepo;
    private readonly IGenericRepository<Customers> _customersRepo;
    private readonly IGenericRepository<ProductOrders> _productOrdersRepo;

    public OrderFinder(IUnitOfWork uow, IGenericRepository<Orders> ordersRepo, IGenericRepository<Customers> customersRepo,
                       IGenericRepository<ProductOrders> productOrdersRepo)
    {
        _uow = uow;
        _ordersRepo = ordersRepo;
        _customersRepo = customersRepo;
        _productOrdersRepo = productOrdersRepo;
    }

    public OrderDto FindOrder(int orderId)
    {
        OrderDto orderDto = new OrderDto();
        var order = _ordersRepo.GetById(orderId);
        orderDto.CustomerId = order.CustomerId;
        orderDto.Address = order.Address;
        var customer = _customersRepo.GetById(order.CustomerId);
        orderDto.CustomerName = customer.Name;
        foreach (var productOrder in _productOrdersRepo.Get(x => x.OrderId == orderId))
        {
            ProductOrderDto productOrderDto = new ProductOrderDto();
            productOrderDto.ProductId = productOrder.ProductId;
            productOrderDto.Price = productOrder.Price;
            productOrderDto.Quantity = productOrder.Quantity;
            orderDto.ProductOrders.Add(productOrderDto);
        }
        return orderDto;
    }
}