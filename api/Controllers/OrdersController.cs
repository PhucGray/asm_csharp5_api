using api.Interfaces;
using api.Models;
using api.Models.OtherModels;
using api.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public IOrder _order;

        public OrdersController(IOrder order)
        {
            _order = order;
        }

        // GET api/orders
        [HttpGet]
        [Route("")]
        public async Task<dynamic> GetAll()
        {
            return await _order.GetAll();
        }

        // GET api/orders/3
        [HttpGet("{id}")]
        public async Task<dynamic> GetById(int id)
        {
            return await _order.GetById(id);
        }

        // GET api/orders/3/orderDetails
        [HttpGet("{orderId}/orderDetails")]
        public async Task<dynamic> GetOrderDetailsByOrderId(int orderId)
        {
            return await _order.GetOrderDetailsByOrderId(orderId);
        }

        // GET api/orders/history/3
        [HttpGet]
        [Route("history/{orderId}")]
        public async Task<dynamic> GetByUserId(int orderId)
        {
            return await _order.GetByUserId(orderId);
        }

        // GET api/orders/statuses
        [Route("statuses")]
        public async Task<dynamic> GetOrderStatuses()
        {
            return await _order.GetOrderStatuses();
        }

        // GET api/orders/vat
        [HttpGet]
        [Route("vat")]
        public async Task<dynamic> GetVAT()
        {
            return await _order.GetVAT();
        }

        // POST api/orders/order
        [HttpPost]
        [Route("order")]
        public async Task<dynamic> AddOrder(OrderModel order)
        {
            return await _order.AddOrder(order);
        }

        // POST api/orders/orderDetails
        [HttpPost]
        [Route("orderDetails")]
        public async Task<dynamic> AddOrderDetails(IEnumerable<OrderDetail> orderDetails)
        {
            return await _order.AddOrderDetails(orderDetails);
        }

        // PUT api/orders/3
        [HttpPut("{id}")]
        public async Task<dynamic> Update(UpdateOrderReqModel updateOrderReq, int id)
        {
            return await _order.Update(updateOrderReq.StatusId, id);
        }
    }
}
