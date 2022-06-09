using System.Collections.Generic;

namespace Lab3Net.Pattern
{
    class University
    {
        public string Name { get; set; }
        List<Student> Students = new();
        public University(string Name)
        {
            this.Name = Name;
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public string GetStudentContracts()
        {
            string all = "";
            foreach (Student s in Students)
            {
                if (s.Form.Equals("Contract"))
                {
                    all += s.ToString() + '\n';
                }
            }
            return all;
        }
        public string GetStudentBudgets()
        {
            string all = "";
            foreach (Student s in Students)
            {
                if (s.Form.Equals("Budget"))
                {
                    all += s.ToString() + '\n';
                }
            }
            return all;
        }
    }
}
