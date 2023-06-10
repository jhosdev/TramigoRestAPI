﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TramigoApplication.Infrastructure.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Dni { get; set; }
    public string Name { get; set; }
    public string LastName1 { get; set; }
    public string LastName2 { get; set; }
    public string Phone { get; set; }
    public bool Verified { get; set; }
    public string PaymentMethod { get; set; }
    public string Company { get; set; }
    public bool IsActive { get; set; }
    //
    public DateTime CreatedAt { get; set; }
    //
    public DateTime UpdatedAt { get; set; }
    //
    public List<Procedure> Procedures { get; set; }
    public List<Payment> Payments { get; set; }

    public User()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}