using Microsoft.EntityFrameworkCore;
using RestoProject.Data;
using RestoProject.Services.CategoryService;
using RestoProject.Shared.Entities;

namespace RestoProject.Services.DishService
{
  public class DishService : IDishService
  {
    private readonly ICategoryService _categoryService;
    private readonly DataContext _context;

    public DishService(ICategoryService categoryService, DataContext context)
    {
      _categoryService = categoryService;
      _context = context;
    }

    public async Task<List<Dish>> GetAllProducts()
    {
      return await _context.TMDish.Include(p => p.Variants).ToListAsync();
    }

    public async Task<Dish> GetProduct(int id)
    {
      Dish dish = await _context.TMDish
        .Include(p => p.Variants)
        .ThenInclude(v => v.Flavor)
        .FirstOrDefaultAsync(p => p.Id == id);

      dish.Views++;

      await _context.SaveChangesAsync();

      return dish;
    }


    public async Task<List<Dish>> GetProductsByCategory(string categoryUrl)
    {
      Category category = await _categoryService.GetCategoryByUrl(categoryUrl);
      return await _context.TMDish.Include(p => p.Variants).Where(p => p.CategoryId == category.Id).ToListAsync();
    }

    public async Task<List<Dish>> SearchProducts(string searchText)
    {
      return await _context.TMDish
        .Where(p => p.Name.Contains(searchText) || p.Description.Contains(searchText))
        .ToListAsync();
    }
  }
}
