using Xunit;

namespace Features.Tests
{
    public class TestNotWorkingBecauseSomething
    {
        [Fact(DisplayName = "Customer v2.0", Skip = "Broken in new version")]
        [Trait("Customer Skip", "Skipping Tests")]
        public void Test_NotWorking_CompatibilityIssue()
        {
            Assert.True(false);
        }
    }
}
