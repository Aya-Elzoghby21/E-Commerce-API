using E_commerce.Models;

namespace E_commerce.Repositry
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<object>> GetAllOrdersWithDetailsAsync();
        Task<IEnumerable<object>> GetOrdersByUserIdAsync(string userId);
        Task<IEnumerable<object>> GetLatestOrdersAsync();
    }
}
