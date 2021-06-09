using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("ProjectB")]
namespace ProjectA
{
    public class PublicClass
    {
        public void TestPublicMethod() { }

        private void TestPrivateMethod() { }

        internal void TestInternalMethod() { }

        protected void TestProtectedMethod() { }

        private protected void TestPrivateProtectedMethod() { }

        protected internal void TestInternalProtectedMethod() { }
    }

    public sealed class SealedClass { }

    class PrivateClass { }

    internal class InternalClass { }

    abstract class AbstractClass { }

    class TestClasses
    {
        public TestClasses()
        {
            var publicClass = new PublicClass();
            var privateClass = new PrivateClass();
            var internalClass = new InternalClass();
            //var abstractClass = new AbstractClass();
        }
    }

    //class TestSealedClass : SealedClass { }

    class TestModifiers
    {
        public TestModifiers()
        {
            var publicClass = new PublicClass();

            publicClass.TestPublicMethod();
            publicClass.TestInternalMethod();
            publicClass.TestInternalProtectedMethod();
            //publicClass.TestProtectedMethod();
            //publicClass.TestPrivateProtectedMethod();
            //publicClass.TestPrivateMethod();
        }
    }

    class TestModifiersWithInheritance : PublicClass
    {
        public TestModifiersWithInheritance()
        {
            TestPublicMethod();
            TestInternalMethod();
            TestProtectedMethod();
            TestInternalProtectedMethod();
            TestPrivateProtectedMethod();
            //TestPrivateMethod();
        }
    }
}

/*******************************************************/
// public:

// Access is not restricted.
/*******************************************************/
// protected:

// Access is limited to the containing class or types
// derived from the containing class.
/*******************************************************/
// internal:

// Access is limited to the current assembly.
/*******************************************************/
// protected internal:

// Access is limited to the current assembly or types
// derived from the containing class.
/*******************************************************/
// private:

// Access is limited to the containing type.
/*******************************************************/
// private protected:

// Access is limited to the containing class or types
// derived from the containing class within the current
// assembly.Available since C# 7.2.
/*******************************************************/
