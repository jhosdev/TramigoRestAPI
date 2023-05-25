using TramigoApplication.Infrastructure.Context;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public class UserSqlInfrastructure : IUserInfrastructure
{
    private TramigoApplicationContext _context;
        
    public UserSqlInfrastructure(TramigoApplicationContext context)
    {
        _context = context;
    }
    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }
    
    public User? GetUser(int id)
    {
        return _context.Users.Find(id);
    }
    
    public bool SaveUser(string name)
    {
        User user = new User();
        user.Name = name;
        user.Username = name;
        user.IsActive = true;
        _context.Users.Add(user);
        _context.SaveChanges();
        return true;
    }
    
    public bool UpdateUser(int id,string name)
    {
        User user = _context.Users.Find(id) ?? throw new InvalidOperationException();
        user.Name = name;
        _context.SaveChanges();
        return true;
    }
    
    public bool DeleteUser(int id)
    {
        User user = _context.Users.Find(id) ?? throw new InvalidOperationException();
        user.IsActive = false;
        
        _context.Users.Update(user);
        
        //_context.Users.Remove(user);  Physical Delete
        
        _context.SaveChanges();
        
        return true;
    }
}