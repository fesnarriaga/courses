using Xunit;

namespace Demo.Tests
{
    public class AssertCollectionTests
    {
        [Fact]
        public void Employee_Skills_ShouldNotHaveEmptySkills()
        {
            // Arrange
            var employee = EmployeeFactory.Create("Felipe", 10000);

            // Act

            // Assert
            Assert.All(employee.Skills, skill => Assert.False(string.IsNullOrWhiteSpace(skill)));
        }

        [Fact]
        public void Employee_Skills_JuniorMustHaveBasicSkill()
        {
            // Arrange
            var employee = EmployeeFactory.Create("Felipe", 1000);

            // Act

            // Assert
            Assert.Contains("OOP", employee.Skills);
        }

        [Fact]
        public void Employee_Skills_JuniorMustNotHaveAdvancedSkill()
        {
            // Arrange
            var employee = EmployeeFactory.Create("Felipe", 1000);

            // Act

            // Assert
            Assert.DoesNotContain("Micro services", employee.Skills);
        }

        [Fact]
        public void Employee_Skills_SeniorMustHaveAllSkills()
        {
            // Arrange
            var employee = EmployeeFactory.Create("Felipe", 10000);

            var allSkills = new[]
            {
                "Programming logic",
                "OOP",
                "Tests",
                "Micro services"
            };

            // Act

            // Assert
            Assert.Equal(allSkills, employee.Skills);
        }
    }
}
