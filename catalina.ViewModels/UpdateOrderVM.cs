using catalina.Repositories.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalina.ViewModels
{
    public class UpdateOrderVM
    {
        public string OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusString { get; set; }
        public Currency Currency { get; set; }
        public decimal ItemValue { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal HandlingFee { get; set; }
    }
}
