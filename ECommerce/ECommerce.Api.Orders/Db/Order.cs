﻿using System;

namespace ECommerce.Api.Orders.Db
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public OrderItem[] Items { get; set; }
    }
}
