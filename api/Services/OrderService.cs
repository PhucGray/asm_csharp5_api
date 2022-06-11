using api.Enums;
using api.Helpers;
using api.Interfaces;
using api.Models;
using api.Models.OtherModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace api.Services
{
    public class OrderService : IOrder
    {
        protected DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            return await _context.Orders
                            .ToListAsync();
        }

        public async Task<OrderModel> GetById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId)
        {
            return await _context.OrderDetails
                            .Where(i => i.OrderId == orderId)
                            .ToListAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetByUserId(int userId)
        {
            try
            {
                var orders = await _context.Orders.Where(order => order.UserId == userId).ToListAsync();

                return orders;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<IEnumerable<OrderStatusModel>> GetOrderStatuses()
        {
            return await _context.OrderStatuses.ToListAsync();
        }

        public async Task<OrderModel> AddOrder(OrderModel order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                _context.SaveChanges();

                return order;
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<IEnumerable<OrderDetail>> AddOrderDetails(IEnumerable<OrderDetail> orderDetails)
        {
            try
            {
                await _context.OrderDetails.AddRangeAsync(orderDetails);
                _context.SaveChanges();
                return orderDetails;
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<OrderModel> Update(int statusId, int id)
        {
            try
            {
                var order = _context.Orders.Find(id);

                order.OrderStatusId = statusId;
               
                await _context.SaveChangesAsync();

                return order;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<double> GetVAT()
        {
            try
            {
                var VAT = await _context.VATs.FindAsync(1);
                return VAT.Value;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
