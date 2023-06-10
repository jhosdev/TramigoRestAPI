using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public interface IReceiptDomain
{
    public bool SaveReceipt(Receipt receipt);
    public bool UpdateReceipt(int id, Receipt receipt);
    public bool DeleteReceipt(int id);
}