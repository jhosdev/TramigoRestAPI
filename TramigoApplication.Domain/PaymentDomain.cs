using TramigoApplication.Infrastructure;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain;

public class PaymentDomain: IPaymentDomain
{
    public IPaymentInfrastructure _paymentInfrastructure;
    
    public PaymentDomain(IPaymentInfrastructure paymentInfrastructure)
    {
        _paymentInfrastructure = paymentInfrastructure;
    }
    
    private bool IsValidData(string name)
    {
        if (name.Length < 3) return  false;
        return true;
    }
    
    public bool SavePayment(Payment payment)
    {
        return _paymentInfrastructure.SavePayment(payment);
    }
    
    public bool UpdatePayment(int id,Payment payment)
    {
        return _paymentInfrastructure.UpdatePayment(id,payment);
    }
    
    public bool DeletePayment(int id)
    {
        return _paymentInfrastructure.DeletePayment(id);
    }

}