using System;

namespace OOP
{
    public class Employee : Person
    {
        public DateTime HireDate { get; set; }
        public string Credential { get; set; }
    }

    public class AdmissionProcess
    {
        public void Execute()
        {
            var employee = new Employee
            {
                Name = "John Doe",
                BirthDate = Convert.ToDateTime("1990/31/05"),
                HireDate = DateTime.Now,
                Credential = "0123456"
            };

            employee.ComputeAge();
        }
    }
}
