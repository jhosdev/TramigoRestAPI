using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public interface IUserInfrastructure
{
    List<User> GetAll();
    User GetUser(int id);
    
    
    
    bool SaveUser(User user);
    bool UpdateUser(int id,User user);
    bool DeleteUser(int id);
}