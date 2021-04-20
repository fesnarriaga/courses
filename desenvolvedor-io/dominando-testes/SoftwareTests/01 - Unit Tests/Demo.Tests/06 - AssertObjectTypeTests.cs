using Xunit;

namespace Demo.Tests
{
    public class AssertObjectTypeTests
    {
        [Fact]
        public void EmployeeFactory_Create_ShouldReturnEmployeeType()
        {
            // Arrange

            // Act
            var employee = EmployeeFactory.Create("Felipe", 10000);

            // Assert
            Assert.IsType<Employee>(employee);
        }

        [Fact]
        public void EmployeeFactory_Create_ShouldReturnInheritedPersonType()
        {
            // Arrange

            // Act
            var employee = EmployeeFactory.Create("Felipe", 10000);

            // Assert
            Assert.IsAssignableFrom<Person>(employee);
        }
    }
}
