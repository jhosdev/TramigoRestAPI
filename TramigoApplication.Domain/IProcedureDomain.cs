using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public interface IProcedureDomain
{
    public bool SaveProcedure(Procedure procedure);
    
    public bool UpdateProcedure(int id, Procedure procedure);
    
    public bool DeleteProcedure(int id);
}