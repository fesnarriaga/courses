using Xunit;

namespace Demo.Tests
{
    public class AssertRangeTests
    {
        [Theory]
        [InlineData(700)]
        [InlineData(1500)]
        [InlineData(2000)]
        [InlineData(7500)]
        [InlineData(8000)]
        [InlineData(15000)]
        public void Employee_Salary_SalaryRangeMustComplySkillLevel(double salary)
        {
            // Arrange

            // Act
            var employee = new Employee("Felipe", salary);

            // Assert
            if (employee.SkillLevel == SkillLevel.Junior)
            {
                Assert.InRange(employee.Salary, 500, 1999);
            }

            if (employee.SkillLevel == SkillLevel.Middle)
            {
                Assert.InRange(employee.Salary, 2000, 7999);
            }

            if (employee.SkillLevel == SkillLevel.Senior)
            {
                Assert.InRange(employee.Salary, 8000, double.MaxValue);
            }

            Assert.NotInRange(employee.Salary, 0, 499);
        }
    }
}
