namespace TramigoApplication.Domain.Test;

using TramigoApplication.Domain;

public class TestableClassUnitTest
{
    [Theory]
    [InlineData(10,10,20)]
    [InlineData(20,30,50)]
    [InlineData(60,30,90)]
    public void sum_ValidValues_ReturnSum(int a, int b, int expected)
    {
        // Arrange
        TestableClass testableClass = new TestableClass();
        // Act
        var result = testableClass.sum(a, b);
        // Assert
        Assert.Equal(expected, result);
    }
}