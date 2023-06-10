﻿using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Infrastructure;

public interface IPaymentInfrastructure
{
    Task<List<Payment>> GetAllAsync();
    
    Payment GetPayment(int id);
    
    bool SavePayment(Payment payment);
    
    bool UpdatePayment(int id,Payment payment);
    
    bool DeletePayment(int id);
}