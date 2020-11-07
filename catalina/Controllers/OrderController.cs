using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalina.Core.Interfaces;
using catalina.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace catalina.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult PostOrder(OrderPostVM order)
        {
            try
            {
                var result = _orderService.SaveOrder(order);
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderVM order)
        {
            try
            {
                var result = _orderService.UpdateOrder(order);
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetByUser(string userId, int offset = 0, int limit = 10)
        {
            try
            {
                var result = _orderService.GetByUser(userId, offset, limit);
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}