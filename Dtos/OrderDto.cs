namespace Dtos;

public class OrderDto
{
    public int CustomerId { get; set; } 

    public string Address { get; set; }

    public string CustomerName { get; set; }

    public List<ProductOrderDto> ProductOrders { get; set; }
}