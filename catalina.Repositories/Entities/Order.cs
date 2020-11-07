using catalina.Repositories.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace catalina.Repositories.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string OrderStatusString { get; set; }
        public string Currency { get; set; }
        [Column(TypeName = "decimal(15,3)")]
        public decimal ItemValue { get; set; }
        [Column(TypeName = "decimal(15,3)")]
        public decimal ShippingCharge { get; set; }
        [Column(TypeName = "decimal(15,3)")]
        public decimal HandlingFee { get; set; }
        public string OrderMetaData { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
    }
}
