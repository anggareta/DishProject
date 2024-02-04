using RestoProject.Shared.Entities;

namespace RestoProject.Client.Services.CategoryService
{
  interface ICategoryService
  {
    List<Category> Categories { get; set; }
    Task LoadCategories();
  }
}
