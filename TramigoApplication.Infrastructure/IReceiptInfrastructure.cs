using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public interface IReceiptInfrastructure
{
    Task<List<Receipt>> GetAllAsync();
    
    Receipt GetReceipt(int id);
    
    bool SaveReceipt(Receipt receipt);
    
    bool UpdateReceipt(int id, Receipt receipt);
    
    bool DeleteReceipt(int id);
}