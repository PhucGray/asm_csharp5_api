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

        public async Task<dynamic> GetAll()
        {
            try
            {
                var orders = await _context.Orders.Include(order => order.User).ToListAsync();
                return new
                {
                    Success = true,
                    Data = orders
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Order(GetAll): error"
                };
            }
        }

        public async Task<dynamic> GetById(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                return new
                {
                    Success = true,
                    Data = order
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Order(GetById): error"
                };
            }
        }

        public async Task<dynamic> GetOrderDetailsByOrderId(int orderId)
        {  
            try
            {
                var orderDetails = await _context.OrderDetails
                            .Where(i => i.OrderId == orderId)
                            .ToListAsync();
                return new
                {
                    Success = true,
                    Data = orderDetails
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Order(GetOrderDetailsByOrderId): error"
                };
            }
        }

        public async Task<dynamic> GetByUserId(int userId)
        {
            try
            {
                var orders = await _context.Orders.Where(order => order.UserId == userId).ToListAsync();

                return new { 
                    Success = true,
                    Data = orders
                };
            }
            catch (Exception)
            {
            }

            return new
            {
                Success = false,
                Message = "Order(GetByUserId): error"
            };
        }

        public async Task<dynamic> GetOrderStatuses()
        {
            try
            {
                var orderStatuses = await _context.OrderStatuses.ToListAsync();
                return new
                {
                    Success = true,
                    Data = orderStatuses
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Order(GetOrderStatuses): error"
                };
            }
        }

        public async Task<dynamic> AddOrder(OrderModel order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                _context.SaveChanges();

                return new {
                    Success = true,
                    Data = order
                };
            }
            catch (Exception)
            {

            }

            return new
            {
                Success = false,
                Message = "Order(AddOrder): error"
            };
        }

        public async Task<dynamic> AddOrderDetails(IEnumerable<OrderDetail> orderDetails)
        {
            try
            {
                await _context.OrderDetails.AddRangeAsync(orderDetails);
                _context.SaveChanges();
                return new
                {
                    Success = true,
                    Data = orderDetails
                };
            }
            catch (Exception)
            {

            }

            return new
            {
                Success = false,
                Message = "Order(AddOrderDetails): error"
            };
        }

        public async Task<dynamic> Update(int statusId, int id)
        {
            try
            {
                var order = _context.Orders.Find(id);

                order.OrderStatusId = statusId;
               
                await _context.SaveChangesAsync();

                return new {
                    Success = true,
                    Data = order
                };
            }
            catch (Exception)
            {
            }

            return new
            {
                Success = false,
                Message = "Order(Update): error"
            };
        }

        public async Task<dynamic> GetVAT()
        {
            try
            {
                var VAT = await _context.VATs.FindAsync(1);

                return new { 
                    Success = true,
                    Data = VAT.Value
                };
            }
            catch (Exception)
            {
            }

            return new
            {
                Success = false,
                Message = "Order(VAT): error"
            };
        }
    }
}
