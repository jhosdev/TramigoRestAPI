using Microsoft.EntityFrameworkCore;
using TramigoApplication.Infrastructure.Context;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public class ProcedureMySqlInfrastructure : IProcedureInfrastructure
{
    private TramigoApplicationContext _context;
    
    public ProcedureMySqlInfrastructure(TramigoApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<Procedure>> GetAllAsync()
    {
        return await _context.Procedures.Where(p=>p.IsActive).ToListAsync();
    }
    
    public Procedure GetProcedure(int id)
    {
        return _context.Procedures.Find(id);
    }
    
    public bool SaveProcedure(Procedure procedure)
    {
        _context.Procedures.Add(procedure);
        _context.SaveChanges();
        return true;
    }
    
    public bool UpdateProcedure(int id,Procedure procedure)
    {
        Procedure _procedure = _context.Procedures.Find(id);
        _context.Entry(_procedure).CurrentValues.SetValues(procedure);
        _context.SaveChanges();
        return true;
    }
    
    public bool DeleteProcedure(int id)
    {
        Procedure _procedure = _context.Procedures.Find(id);
        _procedure.IsActive = false;
        _context.SaveChanges();
        return true;
    }
}