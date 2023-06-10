using TramigoApplication.Domain;
using TramigoApplication.Infrastructure;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.Domain.Test;

using Moq;

public class UserDomainUnitTest
{
    [Fact]
    public void save_ValidObject_ReturnTrue()
    {
        // Arrange
        User user = new User()
        {
            Name = "Test"
        };
        
        //Mock
        var userInfrastructure = new Mock<IUserInfrastructure>();
        userInfrastructure.Setup(x => x.SaveUser(user)).Returns(true);
        
        UserDomain userDomain = new UserDomain(userInfrastructure.Object);
        // Act
        var result = userDomain.SaveUser(user);
        
        // Assert
        Assert.True(result);
    }
}