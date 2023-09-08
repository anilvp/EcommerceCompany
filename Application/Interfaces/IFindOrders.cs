using Dtos;

namespace Application.Interfaces;

public interface IFindOrders
{
    OrderDto FindOrder(int orderId);
}