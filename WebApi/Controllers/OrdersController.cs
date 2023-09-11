﻿using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Dtos;

namespace WebApi.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ICreateOrders _createOrder;
    private readonly IFindOrders _findOrder;

    public OrdersController(ICreateOrders createOrder, IFindOrders findOrder)
    {
        _createOrder = createOrder;
        _findOrder = findOrder;
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }
        _createOrder.Add(dto);
        return Ok();
    }

    [HttpGet]
    public ActionResult<OrderDto> FindOrder(int orderId)
    {
        OrderDto dto = _findOrder.FindOrder(orderId);
        return Ok(dto);
    }
}