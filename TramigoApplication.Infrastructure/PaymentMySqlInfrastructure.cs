using Microsoft.EntityFrameworkCore;
using TramigoApplication.Infrastructure.Context;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public class PaymentMySqlInfrastructure : IPaymentInfrastructure
{
    private TramigoApplicationContext _context;
    
    public PaymentMySqlInfrastructure(TramigoApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<List<Payment>> GetAllAsync()
    {
        return await _context.Payments.Where(p => p.IsActive).ToListAsync();
    }
    
    public Payment GetPayment(int id)
    {
        return _context.Payments.Find(id);
    }
    
    public bool SavePayment(Payment payment)
    {
        _context.Payments.Add(payment);
        _context.SaveChanges();
        return true;
    }
    
    public bool UpdatePayment(int id,Payment payment)
    {
        Payment _payment = _context.Payments.Find(id);
        _context.Entry(_payment).CurrentValues.SetValues(payment);
        _context.SaveChanges();
        return true;
    }
    
    public bool DeletePayment(int id)
    {
        Payment _payment = _context.Payments.Find(id);
        _payment.IsActive = false;
        _context.SaveChanges();
        return true;
    }
}