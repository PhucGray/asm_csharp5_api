using api.Interfaces;
using api.Models;
using api.Models.OtherModels;
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
        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            return await _order.GetAll();
        }

        // GET api/orders/3
        [HttpGet("{id}")]
        public async Task<OrderModel> GetById(int id)
        {
            return await _order.GetById(id);
        }

        // GET api/orders/3/orderDetails
        [HttpGet("{orderId}/orderDetails")]
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId)
        {
            return await _order.GetOrderDetailsByOrderId(orderId);
        }

        // GET api/orders/history/3
        [HttpGet]
        [Route("history/{orderId}")]
        public async Task<IEnumerable<OrderModel>> GetByUserId(int orderId)
        {
            return await _order.GetByUserId(orderId);
        }

        // GET api/orders/statuses
        [Route("statuses")]
        public async Task<IEnumerable<OrderStatusModel>> GetOrderStatuses()
        {
            return await _order.GetOrderStatuses();
        }

        // GET api/orders/vat
        [HttpGet]
        [Route("vat")]
        public async Task<double> GetVAT()
        {
            return await _order.GetVAT();
        }

        // POST api/orders/order
        [HttpPost]
        [Route("order")]
        public async Task<OrderModel> AddOrder(OrderModel order)
        {
            return await _order.AddOrder(order);
        }

        // POST api/orders/orderDetails
        [HttpPost]
        [Route("orderDetails")]
        public async Task<IEnumerable<OrderDetail>> AddOrderDetails(IEnumerable<OrderDetail> orderDetails)
        {
            return await _order.AddOrderDetails(orderDetails);
        }

        // PUT api/orders/3
        [HttpPut("{id}")]
        public async Task<OrderModel> Update(UpdateOrderStatusReqModel updateOrderStatusReq, int id)
        {
            return await _order.Update(updateOrderStatusReq.StatusId, id);
        }
    }
}
