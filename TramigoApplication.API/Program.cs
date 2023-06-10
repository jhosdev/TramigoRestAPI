using Microsoft.EntityFrameworkCore;
using TramigoApplication.Domain;
using TramigoApplication.Infrastructure;
using TramigoApplication.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IUserInfrastructure, UserSqlInfrastructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<ICategoryInfrastructure, CategoryMySqlInfrastructure>();
builder.Services.AddScoped<ICategoryDomain, CategoryDomain>();
builder.Services.AddScoped<IProcedureInfrastructure, ProcedureMySqlInfrastructure>();
builder.Services.AddScoped<IProcedureDomain, ProcedureDomain>();
builder.Services.AddScoped<IPaymentInfrastructure, PaymentMySqlInfrastructure>();
builder.Services.AddScoped<IPaymentDomain, PaymentDomain>();
builder.Services.AddScoped<IReceiptInfrastructure, ReceiptMySqlInfrastructure>();
builder.Services.AddScoped<IReceiptDomain, ReceiptDomain>();

//Cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//Conexion a MySQL 
var connectionString = builder.Configuration.GetConnectionString("tramigoConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));

builder.Services.AddDbContext<TramigoApplicationContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<TramigoApplicationContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();