using TramigoApplication.Infrastructure;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public class CategoryDomain: ICategoryDomain
{
    public ICategoryInfrastructure _categoryInfrastructure;
    
    public CategoryDomain(ICategoryInfrastructure categoryInfrastructure)
    {
        _categoryInfrastructure = categoryInfrastructure;
    }
    
    private bool IsCategoryValid(Category category)
    {
        return category.Name != null && category.Name.Length > 0;
    }
    
    public bool SaveCategory(Category category)
    {
        return _categoryInfrastructure.SaveCategory(category);
    }
    
    public bool UpdateCategory(int id, Category category)
    {
        return _categoryInfrastructure.UpdateCategory(id, category);
    }
    
    public bool DeleteCategory(int id)
    {
        return _categoryInfrastructure.DeleteCategory(id);
    }
}