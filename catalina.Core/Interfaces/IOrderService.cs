using catalina.Repositories.Entities;
using catalina.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalina.Core.Interfaces
{
    public interface IOrderService
    {
        bool SaveOrder(OrderPostVM order);
        Order UpdateOrder(UpdateOrderVM order);
        List<OrderVM> GetByUser(string userId, int offset, int limit);
    }
}
