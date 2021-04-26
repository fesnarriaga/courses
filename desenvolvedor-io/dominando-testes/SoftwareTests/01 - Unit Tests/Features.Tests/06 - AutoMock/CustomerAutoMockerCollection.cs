using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(CustomerAutoMockerCollection))]
    public class CustomerAutoMockerCollection : ICollectionFixture<CustomerAutoMockerFixture>
    {

    }
}
