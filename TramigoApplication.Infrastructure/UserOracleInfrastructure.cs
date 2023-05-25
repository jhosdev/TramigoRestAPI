using TramigoApplication.Infrastructure.Context;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public class UserOracleInfrastructure : IUserInfrastructure
{
    public List<User> GetAll()
    {
        throw new NotImplementedException();
    }
    
    public User? GetUser(int id)
    {
        throw new NotImplementedException();
    }
    
    public bool SaveUser(string name)
    {
        throw new NotImplementedException();
    }
    
    public bool UpdateUser(int id,string name)
    {
        throw new NotImplementedException();
    }
    
    public bool DeleteUser(int id)
    {
        throw new NotImplementedException();
    }
}