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
        Task<IEnumerable<OrderModel>> GetAll();
        Task<OrderModel> GetById(int id);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
        Task<IEnumerable<OrderModel>> GetByUserId(int userId);
        Task<IEnumerable<OrderStatusModel>> GetOrderStatuses();
        Task<OrderModel> AddOrder(OrderModel order);
        Task<IEnumerable<OrderDetail>> AddOrderDetails(IEnumerable<OrderDetail> orderDetails);
        Task<OrderModel> Update(int statusId, int id);
        //
        Task<double> GetVAT();
    }
}
