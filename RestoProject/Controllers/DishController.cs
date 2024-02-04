using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoProject.Services.DishService;
using RestoProject.Shared.Entities;

namespace RestoProject.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DishController : ControllerBase
  {
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
      _dishService = dishService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Dish>>> GetAllProducts()
    {
      return Ok(await _dishService.GetAllProducts());
    }

    [HttpGet("Category/{categoryUrl}")]
    public async Task<ActionResult<List<Dish>>> GetProductsByCategory(string categoryUrl)
    {
      return Ok(await _dishService.GetProductsByCategory(categoryUrl));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dish>> GetProduct(int id)
    {
      return Ok(await _dishService.GetProduct(id));
    }

    [HttpGet("Search/{searchText}")]
    public async Task<ActionResult<List<Dish>>> SearchProducts(string searchText)
    {
      return Ok(await _dishService.SearchProducts(searchText));
    }
  }
}
