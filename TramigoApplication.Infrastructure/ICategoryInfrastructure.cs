using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public interface ICategoryInfrastructure
{
    Task<List<Category>> GetAllAsync();
    
    Category GetCategory(int id);
    
    bool SaveCategory(Category category);
    
    bool UpdateCategory(int id,Category category);
    
    bool DeleteCategory(int id);
}