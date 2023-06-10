using Microsoft.EntityFrameworkCore;
using TramigoApplication.Infrastructure.Context;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public class ReceiptMySqlInfrastructure : IReceiptInfrastructure
{
    private TramigoApplicationContext _context;
    
    public ReceiptMySqlInfrastructure(TramigoApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<Receipt>> GetAllAsync()
    {
        return await _context.Receipts.ToListAsync();
    }
    
    public Receipt GetReceipt(int id)
    {
        return _context.Receipts.Find(id);
    }
    
    public bool SaveReceipt(Receipt receipt)
    {
        _context.Receipts.Add(receipt);
        _context.SaveChanges();
        return true;
    }
    
    public bool UpdateReceipt(int id,Receipt _receipt)
    {
        var receipt = _context.Receipts.Find(id);
        _context.Entry(receipt).CurrentValues.SetValues(_receipt);
        _context.SaveChanges();
        return true;
    }
    
    public bool DeleteReceipt(int id)
    {
        throw new NotImplementedException();
    }
}