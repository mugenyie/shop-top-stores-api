using catalina.Core.Helpers;
using catalina.Core.Interfaces;
using catalina.Repositories;
using catalina.Repositories.Entities;
using catalina.Repositories.Enums;
using catalina.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace catalina.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public List<OrderVM> GetByUser(string userId, int offset, int limit)
        {
            List<OrderVM> ordersVm = new List<OrderVM>();
            var orders = _orderRepository.Query().Where(x => x.UserId.Equals(new Guid(userId))).OrderByDescending(x => x.CreatedOnUTC).Take(10).ToList();
            if(orders != null)
            {
                orders.ForEach(o => ordersVm.Add(new OrderVM
                {
                    OrderId = o.OrderId.ToString(),
                    OrderNumber = o.OrderNumber,
                    OrderStatus = o.OrderStatus,
                    OrderStatusString = o.OrderStatusString.ToLower(),
                    Currency = o.Currency,
                    ItemValue = o.ItemValue,
                    HandlingFee = o.HandlingFee,
                    ShippingCharge = o.ShippingCharge,
                    CreatedOnUTC = o.CreatedOnUTC.ToString("yyyy-MM-dd") + " (GMT)",
                    OrderMetaData = JsonConvert.DeserializeObject<OrderMetaData>(o.OrderMetaData)
                }));
            }
            return ordersVm;
        }

        public bool SaveOrder(OrderPostVM order)
        {
            var user = _userRepository.GetById(new Guid(order.UserId));
            if (user != null)
            {
                var newOrder = new Order()
                {
                    OrderId = Guid.NewGuid(),
                    UserId = new Guid(order.UserId),
                    OrderStatus = OrderStatus.PROCESSING,
                    OrderStatusString = OrderStatus.PROCESSING.ToString(),
                    OrderMetaData = order.OrderMetaData.ToString(),
                    CreatedOnUTC = DateTime.UtcNow,
                    OrderNumber = StringHelpers.RandomString(6)
                };
                _orderRepository.Add(newOrder);
                return true;
            }
            else
            {
                throw new Exception("User does not exist");
            }
        }

        public Order UpdateOrder(UpdateOrderVM order)
        {
            if (!string.IsNullOrEmpty(order.OrderId))
            {
                var existingOrder = _orderRepository.GetById(new Guid(order.OrderId));
                if(existingOrder != null)
                {
                    existingOrder.ItemValue = order.ItemValue;
                    existingOrder.OrderStatus = order.OrderStatus;
                    existingOrder.OrderStatusString = string.IsNullOrEmpty(order.OrderStatusString) ? order.OrderStatus.ToString() : order.OrderStatusString;
                    existingOrder.Currency = order.Currency.ToString();
                    existingOrder.ItemValue = order.ItemValue;
                    existingOrder.ShippingCharge = order.ShippingCharge;
                    existingOrder.HandlingFee = order.HandlingFee;
                    existingOrder.UpdatedOnUTC = DateTime.UtcNow;

                    _orderRepository.Update(existingOrder);

                    return existingOrder;
                }
            }
            throw new Exception("Order not found");
        }
    }
}
