using ECommerce.Api.Orders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrderItemsProvider
    {
        Task<(bool IsSuccess, IEnumerable<OrderItemModel> OrderItems, string ErrorMessage)> GetOrderItemsAsync();

        Task<(bool IsSuccess, OrderItemModel OrderItem, string ErrorMessage)> GetOrderItemAsync(int id);
    }
}
