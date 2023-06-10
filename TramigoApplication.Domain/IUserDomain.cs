using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public interface IUserDomain
{
    public bool SaveUser(User user);
    public bool UpdateUser(int id, User user);
    public bool DeleteUser(int id);
}