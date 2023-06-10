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
        return _context.Users.Where(category => category.IsActive).ToList();
    }
    
    public User? GetUser(int id)
    {
        return _context.Users.Find(id);
    }
    
    public bool SaveUser(User user)
    {
        /*
            User user = new User();
            user.Name = _user.Name;
            user.Username = _user.Name;
            user.IsActive = true;
         */
        
        _context.Users.Add(user);
        _context.SaveChanges();
        
        return true;
    }
    
    public bool UpdateUser(int id,User _user)
    {
        var user = _context.Users.Find(id) ?? throw new InvalidOperationException();
        
        _context.Entry(user).CurrentValues.SetValues(_user);
        
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