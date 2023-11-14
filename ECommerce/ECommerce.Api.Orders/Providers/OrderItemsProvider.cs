using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Providers
{
    public class OrderItemsProvider : IOrderItemsProvider
    {
        private readonly OrdersDbContext dbContext;
        private readonly ILogger<OrderItemsProvider> logger;
        private readonly IMapper mapper;

        public OrderItemsProvider(OrdersDbContext dbContext, ILogger<OrderItemsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            //SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.OrderItems.Any())
            {
                //add sample data
            }
        }

        public async Task<(bool IsSuccess, OrderItemModel OrderItem, string ErrorMessage)> GetOrderItemAsync(int id)
        {
            try
            {
                var orderItem = await dbContext.OrderItems.FirstOrDefaultAsync(p => p.Id == id);

                if (orderItem != null)
                {
                    var result = mapper.Map<OrderItem, OrderItemModel>(orderItem);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderItemModel> OrderItems, string ErrorMessage)> GetOrderItemsAsync()
        {
            try
            {
                var orderItems = await dbContext.OrderItems.ToListAsync();
                if(orderItems != null && orderItems.Any())
                {
                    var result = mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemModel>>(orderItems);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
