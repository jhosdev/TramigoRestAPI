using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public interface IPaymentDomain
{
    public bool SavePayment(Payment payment);
    
    public bool UpdatePayment(int id, Payment payment);
    
    public bool DeletePayment(int id);
}