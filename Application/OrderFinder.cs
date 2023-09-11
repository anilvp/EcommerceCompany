using Application.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Domain;
using Dtos;

namespace Application;

public class OrderFinder : IFindOrders
{
    private readonly IGenericRepository<Order> _ordersRepo;

    public OrderFinder(IGenericRepository<Order> ordersRepo)
    {
        _ordersRepo = ordersRepo;
    }

    public OrderDto FindOrder(int orderId)
    {
        var orderDto = _ordersRepo.Get(x => x.OrderId == orderId)
            .Select(x => new OrderDto()
            {
                Address = x.Address,
                CustomerId = x.CustomerId,
                CustomerName = x.Customer.Name,
                ProductOrders = x.ProductOrders.Select(y => new ProductOrderDto()
                {
                    ProductId = y.ProductId,
                    Price = y.Price,
                    Quantity = y.Quantity
                }
                ).ToList()
            }
            ).Single();
        if (orderDto == null)
        {
            throw new Exception("No order found with order ID: " + orderId);
        }
        return orderDto;
    }
}