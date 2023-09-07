using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Dtos;

namespace WebApi.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ICreateOrders _createOrder;

    public OrdersController(ICreateOrders createOrder)
    {
        _createOrder = createOrder;
    }

    [HttpPost]
    public void CreateOrder([FromBody] OrderDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        _createOrder.Add(dto);
    }
}