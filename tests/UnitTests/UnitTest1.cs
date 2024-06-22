using Xunit;
using NSubstitute;

using DkCprGenerator.Interfaces;
using DkCprGenerator.Model;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestDisplayStrategyInterface()
        {
            // Arrange
            var person = new Person
            {
                Name = "John Doe",
                CprNo = "123456-7890"
            };

            var displayStrategy = Substitute.For<IDisplayStrategy>();
            displayStrategy.Display(person);

            // Act
            displayStrategy.Received().Display(person);

            // Assert
            Assert.True(true);
        }
    }
}
