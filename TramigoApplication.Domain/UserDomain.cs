
using TramigoApplication.Infrastructure;

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
    
    public bool SaveUser(string name)
    {
        if (!this.IsValidData(name)) throw new Exception("Name should be at least 3 characters long");
        return _userInfrastructure.SaveUser(name);
    }
    
    public bool UpdateUser(int id,string name)
    {
        if (!this.IsValidData(name)) throw new Exception("Name should be at least 3 characters long");
        return _userInfrastructure.UpdateUser(id,name);
    }
    
    public bool DeleteUser(int id)
    {
        return _userInfrastructure.DeleteUser(id);
    }
}