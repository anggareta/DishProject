using Microsoft.EntityFrameworkCore;
using RestoProject.Data;
using RestoProject.Shared.Entities;

namespace RestoProject.Services.CategoryService
{
  public class CategoryService : ICategoryService
  {
    private readonly DataContext _context;

    public CategoryService(DataContext context)
    {
      _context = context;
    }

    public async Task<List<Category>> GetCategories()
    {
      return await _context.TMCategory.ToListAsync();
    }

    public async Task<Category> GetCategoryByUrl(string categoryUrl)
    {
      return await _context.TMCategory.FirstOrDefaultAsync(c => c.Url.ToLower().Equals(categoryUrl.ToLower()));
    }
  }
}
