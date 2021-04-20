using Xunit;

namespace Demo.Tests
{
    public class AssertNullBoolTests
    {
        [Fact]
        public void Employee_Name_ShouldNotBeNullOrEmpty()
        {
            // Arrange

            // Act
            var employee = new Employee("", 1000);

            // Assert
            Assert.False(string.IsNullOrEmpty(employee.Name));
        }

        [Fact]
        public void Employee_Alias_ShouldNotHaveAlias()
        {
            // Arrange
            var employee = new Employee("Felipe", 1000);

            // Act

            // Assert
            Assert.Null(employee.Alias);

            Assert.True(string.IsNullOrEmpty(employee.Alias));
            Assert.False(employee.Alias?.Length > 0);
        }
    }
}
