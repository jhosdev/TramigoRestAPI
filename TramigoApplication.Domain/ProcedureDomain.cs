using TramigoApplication.Infrastructure;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public class ProcedureDomain : IProcedureDomain
{
    public IProcedureInfrastructure _procedureInfrastructure;
    
    public ProcedureDomain(IProcedureInfrastructure procedureInfrastructure)
    {
        _procedureInfrastructure = procedureInfrastructure;
    }
    
    private bool IsValidData(string name)
    {
        if (name.Length < 3) return  false;
        return true;
    }

    public bool SaveProcedure(Procedure procedure)
    {
        return _procedureInfrastructure.SaveProcedure(procedure);
    }
    
    public bool UpdateProcedure(int id,Procedure procedure)
    {
        return _procedureInfrastructure.UpdateProcedure(id,procedure);
    }
    
    public bool DeleteProcedure(int id)
    {
        return _procedureInfrastructure.DeleteProcedure(id);
    }
    
}