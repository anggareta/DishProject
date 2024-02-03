using RestoProject.Data;
using RestoProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RestoProject.Controllers
{
  [Route("api/dishorders")]
  [ApiController]
  public class DishOrdersController : ControllerBase
  {
    private readonly DataContext _context;

    public DishOrdersController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<DishOrder>>> GetAllOrdersAsync()
    {
      return await _context.TMDishOrders.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<DishOrder>>> GetOrderByIdAsync(string id)
    {
      var result = await _context.TMDishOrders.FindAsync(id);
      if (result == null)
        return NotFound();

      return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderAsync(string id)
    {
      var result = await _context.TMDishOrders.FindAsync(id);
      if (result == null)
        return NotFound();

      _context.Remove(result);
      await _context.SaveChangesAsync();

      return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<DishOrder>>> UpdateOrderAsync(string id, DishOrder updatedOrder)
    {
      var dbOrder = await _context.TMDishOrders.FindAsync(id);
      if (dbOrder == null)
        return NotFound();

      dbOrder.Name = updatedOrder.Name;
      dbOrder.Description = updatedOrder.Description;
      dbOrder.OrderTime = DateTime.Now;

      await _context.SaveChangesAsync();

      return Ok(dbOrder);
    }

    [HttpPost]
    public async Task<ActionResult<List<DishOrder>>> NewDishOrderAsync(DishOrder newOrder)
    {
      _context.TMDishOrders.Add(newOrder);
      await _context.SaveChangesAsync();

      return Ok(newOrder);
    }

  }
}
