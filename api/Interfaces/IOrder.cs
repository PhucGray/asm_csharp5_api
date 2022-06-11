using api.Models;
using api.Models.OtherModels;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IOrder
    {
        Task<dynamic> GetAll();
        Task<dynamic> GetById(int id);
        Task<dynamic> GetOrderDetailsByOrderId(int orderId);
        Task<dynamic> GetByUserId(int userId);
        Task<dynamic> GetOrderStatuses();
        Task<dynamic> AddOrder(OrderModel order);
        Task<dynamic> AddOrderDetails(IEnumerable<OrderDetail> orderDetails);
        Task<dynamic> Update(int statusId, int id);
        Task<dynamic> GetVAT();
    }
}
