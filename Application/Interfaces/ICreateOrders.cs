using Dtos;

namespace Application.Interfaces;

public interface ICreateOrders
{
    void Add(OrderDto orderDto);
}