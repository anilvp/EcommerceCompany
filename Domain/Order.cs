﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain;

public class Order
{
    private Order() 
    {
        Deliveries = new List<Delivery>();
        ProductOrders = new List<ProductOrder>();
    }

    //Ids are handled by entity framework
    public Order(/*int customerId,*/ string address, List<ProductOrder> productOrders) : this()
    {
        Date = DateTime.Now;
        //CustomerId = customerId;
        Address = address;
        foreach (var productOrder in productOrders)
        {
            ProductOrders.Add(productOrder);
        }
    }

    public int OrderId { get; private set; }

    public DateTime? Date { get; private set; }

    public int CustomerId { get; private set; }

    public string Address { get; private set; }

    public virtual Customer Customer { get; private set; }

    public virtual ICollection<Delivery> Deliveries { get; private set; } 

    public virtual ICollection<ProductOrder> ProductOrders { get; private set; }
}