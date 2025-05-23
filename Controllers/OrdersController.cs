using E_commerce.Repositry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrdersController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("all-orders")]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderRepository.GetAllOrdersWithDetailsAsync();
        return Ok(orders);
    }

    [Authorize]
    [HttpGet("user-orders/{userId}")]
    public async Task<IActionResult> GetOrdersByUser(string userId)
    {
        var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
        return Ok(orders);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("latest-orders")]
    public async Task<IActionResult> GetLatestOrders()
    {
        var orders = await _orderRepository.GetLatestOrdersAsync();
        return Ok(orders);
    }

}
