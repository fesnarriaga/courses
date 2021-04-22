using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(CustomerBogusCollection))]
    public class CustomerBogusCollection : ICollectionFixture<CustomerBogusTestsFixture> { }
}
