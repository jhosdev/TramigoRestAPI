using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public interface IProcedureInfrastructure
{
    Task<List<Procedure>> GetAllAsync();
    
    Procedure GetProcedure(int id);
    
    bool SaveProcedure(Procedure procedure);
    
    bool UpdateProcedure(int id,Procedure procedure);
    
    bool DeleteProcedure(int id);
}