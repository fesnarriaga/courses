using System;

namespace OOP
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public int ComputeAge()
        {
            var today = DateTime.Now;

            var age = today.Year - BirthDate.Year;

            if (today < BirthDate.AddYears(age))
                age--;

            return age;
        }
    }
}
