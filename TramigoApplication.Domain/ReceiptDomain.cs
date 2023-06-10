using TramigoApplication.Infrastructure;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public class ReceiptDomain : IReceiptDomain
{
    public IReceiptInfrastructure _receiptInfrastructure;
    
    public ReceiptDomain(IReceiptInfrastructure receiptInfrastructure)
    {
        _receiptInfrastructure = receiptInfrastructure;
    }
    
    private bool IsValidData(string name)
    {
        if (name.Length < 3) return  false;
        return true;
    }
    
    public bool SaveReceipt(Receipt receipt)
    {
        if (!this.IsValidData(receipt.Title)) throw new Exception("Name should be at least 3 characters long");
        return _receiptInfrastructure.SaveReceipt(receipt);
    }
    
    public bool UpdateReceipt(int id,Receipt receipt)
    {
        if (!this.IsValidData(receipt.Title)) throw new Exception("Name should be at least 3 characters long");
        return _receiptInfrastructure.UpdateReceipt(id,receipt);
    }
    
    public bool DeleteReceipt(int id)
    {
        return _receiptInfrastructure.DeleteReceipt(id);
    }
}