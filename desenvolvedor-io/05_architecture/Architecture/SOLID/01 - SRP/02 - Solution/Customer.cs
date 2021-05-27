using System;

namespace SOLID
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public Document Document { get; set; }
        public DateTime Birth { get; set; }

        public bool Validate()
        {
            return Email.Validate() && Document.Validate();
        }
    }
}
