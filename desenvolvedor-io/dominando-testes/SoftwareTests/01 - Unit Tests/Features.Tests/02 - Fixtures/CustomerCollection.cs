using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(CustomerCollection))]
    public class CustomerCollection : ICollectionFixture<CustomerTestsFixture> { }
}
