using System;
using Lab3Net.Pattern;
using System.Collections.Generic;

namespace Lab3Net
{
    class Program
    {
        static void Main(string[] args)
        {
            University KPI = new("KPI");
            University KNU = new("KNU");
            Builder Bbuilder = new bachelorBuilder();
            Builder Mbuilder = new MasterBuilder();
            Builder Pbuilder = new PhDBuilder();
            Director director = new Director();
            List<Student> students = new();
            students.Add(director.ConstructBudget(Bbuilder, "Alex", "Pirate", KPI));
            students.Add(director.ConstructContract(Bbuilder, "Indoor", "Crayon", KNU));
            students.Add(director.ConstructContract(Mbuilder, "Zinaida", "Melnyk", KPI));
            students.Add(director.ConstructBudget(Mbuilder, "Denys", "Bobrov", KNU));
            students.Add(director.ConstructBudget(Pbuilder, "Ostap", "Shwetz", KPI));
            students.Add(director.ConstructContract(Pbuilder, "Vasyl", "Holub", KNU));
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("\nKPI Budgets :\n" + KPI.GetStudentBudgets());
            Console.WriteLine("\nKNU Contracts :\n" + KNU.GetStudentContracts());
        }
    }
}
