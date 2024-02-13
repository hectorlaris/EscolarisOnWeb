using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
		void AddCategory(Category category);
		IEnumerable<Category> GetCategories();
        void DeleteCategory(int categoryId);
        Category? GetCategoryById(int categoryId);
        void UpdateCategory(int categoryId, Category category);
    }
}