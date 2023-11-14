using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Models;

namespace ECommerce.Api.Orders.Profiles
{
    public class OrderItemProfile : AutoMapper.Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemModel>();
        }
    }
}
