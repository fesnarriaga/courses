using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertExceptionTests
    {
        [Fact]
        public void Calculator_Div_ShouldThrowDivideByZeroException()
        {
            // Arrange
            var calculator = new Calculator();

            // Act

            // Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Div(1, 0));
        }

        [Fact]
        public void Employee_Salary_ShouldThrowExceptionWhenSalaryIsLowerThanMinimum()
        {
            // Arrange

            // Act

            // Assert
            var exception = Assert.Throws<Exception>(() => EmployeeFactory.Create("Felipe", 250));

            Assert.Equal("Salary lower than minimum", exception.Message);
        }
    }
}
