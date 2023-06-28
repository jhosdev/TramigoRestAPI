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
    
    public List<Payment> GetUserPayments(int id)
    {
        throw new NotImplementedException();
    }
    
    public bool SaveUser(User user)
    {
        throw new NotImplementedException();
    }
    
    public bool UpdateUser(int id,User user)
    {
        throw new NotImplementedException();
    }
    
    public bool DeleteUser(int id)
    {
        throw new NotImplementedException();
    }
}