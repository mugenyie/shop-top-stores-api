using catalina.Repositories.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalina.ViewModels
{
    public class OrderVM
    {
        public string OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderStatusString { get; set; }
        public string Currency { get; set; }
        public decimal ItemValue { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal HandlingFee { get; set; }
        public OrderMetaData OrderMetaData { get; set; }
        public string CreatedOnUTC { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public class CartItem
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class OrderMetaData
    {
        public List<CartItem> items { get; set; }
        public string comments { get; set; }
    }
}
