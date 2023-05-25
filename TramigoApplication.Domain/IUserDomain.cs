namespace TramigoApplication.Domain;

public interface IUserDomain
{
    public bool SaveUser(string name);
    public bool UpdateUser(int id, string name);
    public bool DeleteUser(int id);
}