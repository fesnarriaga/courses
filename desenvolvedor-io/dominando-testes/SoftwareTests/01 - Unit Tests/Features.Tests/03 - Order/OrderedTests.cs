using System.Reflection;
using Xunit;

namespace Features.Tests
{
    [TestCaseOrderer("Features.Tests.PriorityOrderer", "Features.Tests")]
    public class OrderedTests
    {
        public static bool Test01Call;
        public static bool Test02Call;
        public static bool Test03Call;
        public static bool Test04Call;

        [Fact(DisplayName = "Test 04"), TestPriority(3)]
        [Trait("Ordered", "Ordered Tests")]
        public void Test04()
        {
            Test04Call = true;

            Assert.True(Test03Call);
            Assert.True(Test01Call);
            Assert.False(Test02Call);
        }

        [Fact(DisplayName = "Test 01"), TestPriority(2)]
        [Trait("Ordered", "Ordered Tests")]
        public void Test01()
        {
            Test01Call = true;

            Assert.True(Test03Call);
            Assert.False(Test04Call);
            Assert.False(Test02Call);
        }

        [Fact(DisplayName = "Test 03"), TestPriority(1)]
        [Trait("Ordered", "Ordered Tests")]
        public void Test03()
        {
            Test03Call = true;

            Assert.False(Test01Call);
            Assert.False(Test02Call);
            Assert.False(Test04Call);
        }

        [Fact(DisplayName = "Test 02"), TestPriority(4)]
        [Trait("Ordered", "Ordered Tests")]
        public void Test02()
        {
            Test02Call = true;

            Assert.True(Test03Call);
            Assert.True(Test04Call);
            Assert.True(Test01Call);
        }
    }
}
