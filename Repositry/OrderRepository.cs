using E_commerce.Models.context;
using E_commerce.Models;
using E_commerce.Repositry;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetAllOrdersWithDetailsAsync()
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
            .Select(o => new
            {
                o.Id,
                o.CreatedAt,
                o.TotalAmount,
                o.Status,
                User = new
                {
                    o.User.Id,
                    o.User.UserName,
                    o.User.Email
                },
                Items = o.OrderItems.Select(i => new {
                    i.ProductId,
                    i.Product.Name,
                    i.Quantity,
                    i.Price
                })
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetOrdersByUserIdAsync(string userId)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
            .Select(o => new
            {
                o.Id,
                o.CreatedAt,
                o.TotalAmount,
                o.Status,
                Items = o.OrderItems.Select(i => new {
                    i.ProductId,
                    i.Product.Name,
                    i.Quantity,
                    i.Price
                })
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetLatestOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
            .OrderByDescending(o => o.CreatedAt)
            .Take(5)
            .Select(o => new
            {
                o.Id,
                o.CreatedAt,
                o.TotalAmount,
                o.Status,
                User = new
                {
                    o.User.Id,
                    o.User.UserName,
                    o.User.Email
                },
                Items = o.OrderItems.Select(i => new {
                    i.ProductId,
                    i.Product.Name,
                    i.Quantity,
                    i.Price
                })
            })
            .ToListAsync();
    }
}
