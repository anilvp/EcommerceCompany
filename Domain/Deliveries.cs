﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Domain;

public class Deliveries
{
    private Deliveries() { }

    public int DeliveryId { get; private set; }

    public int? OrderId { get; private set; }

    public bool? SuccessfullyDelivered { get; private set; }

    public DateTime? Date { get; private set; }

    public virtual Orders Order { get; private set; }
}