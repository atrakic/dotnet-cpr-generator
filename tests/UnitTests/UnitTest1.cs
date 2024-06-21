namespace UnitTests;

using DkCprGenerator.Interfaces;
using DkCprGenerator.Model;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var person = new Person
        {
            Name = "John Doe",
            CprNo = "010203-1234"
        };

        var displayStrategy = new PlainDisplayStrategy();


        // Act
        //var result = displayStrategy.Display(person);

        // Assert
        //Xunit.Assert.Equal("CPR: 010203-1234 Name: John Doe", result);
    }
}
