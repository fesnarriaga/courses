using System;

namespace ModelApp.MVC.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public Student()
        {
            Id = Guid.NewGuid();
        }
    }
}
