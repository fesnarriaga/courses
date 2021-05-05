using System;

namespace SOLID.DemoSolution
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Document Document { get; set; }
        public Email Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool Validate()
        {
            return Document.Validate() && Email.Validate();
        }
    }
}
