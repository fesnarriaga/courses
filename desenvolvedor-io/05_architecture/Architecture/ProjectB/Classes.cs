using ProjectA;

namespace ProjectB
{
    class TestClasses
    {
        public TestClasses()
        {
            var publicClass = new PublicClass();
            //var privateClass = new PrivateClass();
            //var internalClass = new InternalClass();
            //var abstractClass = new AbstractClass();
        }
    }

    class TestModifiers
    {
        public TestModifiers()
        {
            var publicClass = new PublicClass();

            publicClass.TestPublicMethod();
            //publicClass.TestPrivateMethod();
            //publicClass.TestInternalMethod();
            //publicClass.TestProtectedMethod();
            //publicClass.TestPrivateProtectedMethod();
            //publicClass.TestInternalProtectedMethod();
        }
    }

    class TestModifiersWithInheritance : PublicClass
    {
        public TestModifiersWithInheritance()
        {
            var publicClass = new PublicClass();

            TestPublicMethod();
            //TestPrivateMethod();
            //TestInternalMethod();
            TestProtectedMethod();
            //TestPrivateProtectedMethod();
            TestInternalProtectedMethod();
        }
    }
}
