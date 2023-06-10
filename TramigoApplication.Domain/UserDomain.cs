
using TramigoApplication.Infrastructure;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public class UserDomain : IUserDomain
{
    public IUserInfrastructure _userInfrastructure;
    
    public UserDomain(IUserInfrastructure userInfrastructure)
    {
        _userInfrastructure = userInfrastructure;
    }
    
    private bool IsValidData(string name)
    {
        if (name.Length < 3) return  false;
        return true;
    }
    
    public bool SaveUser(User user)
    {
        if (!this.IsValidData(user.Name)) throw new Exception("Name should be at least 3 characters long");
        return _userInfrastructure.SaveUser(user);
    }
    
    public bool UpdateUser(int id,User user)
    {
        if (!this.IsValidData(user.Name)) throw new Exception("Name should be at least 3 characters long");
        return _userInfrastructure.UpdateUser(id,user);
    }
    
    public bool DeleteUser(int id)
    {
        return _userInfrastructure.DeleteUser(id);
    }
}