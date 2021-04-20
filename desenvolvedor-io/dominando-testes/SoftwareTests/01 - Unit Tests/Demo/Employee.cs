using System;
using System.Collections.Generic;

namespace Demo
{
    public class Employee : Person
    {
        public double Salary { get; private set; }

        public SkillLevel SkillLevel { get; private set; }

        public IList<string> Skills { get; set; }

        public Employee(string name, double salary)
        {
            Name = string.IsNullOrEmpty(name) ? "Anonymous" : name;

            SetSalary(salary);
            SetSkills();
        }

        private void SetSalary(double salary)
        {
            if (salary < 500)
                throw new Exception("Salary lower than minimum");

            Salary = salary;

            SkillLevel = salary switch
            {
                < 2000 => SkillLevel.Junior,
                >= 2000 and < 8000 => SkillLevel.Middle,
                >= 8000 => SkillLevel.Senior,
                _ => SkillLevel
            };
        }

        private void SetSkills()
        {
            var basicSkills = new List<string>()
            {
                "Programming logic",
                "OOP"
            };

            Skills = basicSkills;

            switch (SkillLevel)
            {
                case SkillLevel.Middle:
                    Skills.Add("Tests");
                    break;
                case SkillLevel.Senior:
                    Skills.Add("Tests");
                    Skills.Add("Micro services");
                    break;
            }
        }
    }
}
