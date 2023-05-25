using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public interface IUserInfrastructure
{
    List<User> GetAll();
    
    User? GetUser(int id);
    bool SaveUser(string name);
    bool UpdateUser(int id,string name);
    bool DeleteUser(int id);
}