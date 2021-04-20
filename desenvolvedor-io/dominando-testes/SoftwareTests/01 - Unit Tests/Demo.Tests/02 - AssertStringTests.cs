using Xunit;

namespace Demo.Tests
{
    public class AssertStringTests
    {
        [Fact]
        public void StringUtils_Join_ReturnFullName()
        {
            // Arrange
            var sut = new StringUtils();

            // Act
            var fullName = sut.Join("Felipe", "Esnarriaga");

            // Assert
            Assert.Equal("Felipe Esnarriaga", fullName);
        }

        [Fact]
        public void StringUtils_Join_ShouldIgnoreCase()
        {
            // Arrange
            var sut = new StringUtils();

            // Act
            var fullName = sut.Join("Felipe", "Esnarriaga");

            // Assert
            Assert.Equal("FELIPE ESNARRIAGA", fullName, ignoreCase: true);
        }

        [Fact]
        public void StringUtils_Join_ShouldContain()
        {
            // Arrange
            var sut = new StringUtils();

            // Act
            var fullName = sut.Join("Felipe", "Esnarriaga");

            // Assert
            Assert.Contains("ipe", fullName);
        }

        [Fact]
        public void StringUtils_Join_ShouldStartsWith()
        {
            // Arrange
            var sut = new StringUtils();

            // Act
            var fullName = sut.Join("Felipe", "Esnarriaga");

            // Assert
            Assert.StartsWith("Fel", fullName);
        }

        [Fact]
        public void StringUtils_Join_ShouldEndsWith()
        {
            // Arrange
            var sut = new StringUtils();

            // Act
            var fullName = sut.Join("Felipe", "Esnarriaga");

            // Assert
            Assert.EndsWith("aga", fullName);
        }

        [Fact]
        public void StringUtils_Join_ShouldTestRegex()
        {
            // Arrange
            var sut = new StringUtils();

            // Act
            var fullName = sut.Join("Felipe", "Esnarriaga");

            // Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }
    }
}
