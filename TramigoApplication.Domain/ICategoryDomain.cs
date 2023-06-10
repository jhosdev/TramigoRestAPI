using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public interface ICategoryDomain
{
    public bool SaveCategory(Category category);
    
    public bool UpdateCategory(int id, Category category);
    
    public bool DeleteCategory(int id);
}