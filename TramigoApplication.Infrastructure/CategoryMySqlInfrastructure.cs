using Microsoft.EntityFrameworkCore;
using TramigoApplication.Infrastructure.Context;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public class CategoryMySqlInfrastructure : ICategoryInfrastructure
{
    private TramigoApplicationContext _context;
    
    public CategoryMySqlInfrastructure(TramigoApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    
    public Category GetCategory(int id)
    {
        return _context.Categories.Find(id);
    }
    
    public bool SaveCategory(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return true;
    }
    
    public bool UpdateCategory(int id,Category category)
    {
        Category _category = _context.Categories.Find(id);
        _context.Entry(_category).CurrentValues.SetValues(category);
        _context.SaveChanges();
        return true;
    }
    
    public bool DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }
}