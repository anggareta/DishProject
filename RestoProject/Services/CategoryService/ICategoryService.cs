using RestoProject.Shared.Entities;

namespace RestoProject.Services.CategoryService
{
  public interface ICategoryService
  {
    Task<List<Category>> GetCategories();

    Task<Category> GetCategoryByUrl(string categoryUrl);
  }
}
