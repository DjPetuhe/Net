using System;

namespace Lab3Net.Pattern
{
    interface Builder
    {
        public void BuildName(string Name, string Surname);
        public void BuildUniversity(University Univ);
        public void BuildBudget(bool budget);
        public void BuildDegree();
        public void BuildYearOfAdmission();
        public void BuildYearOfEnd();
        public Student GetResult();
    }

    class bachelorBuilder : Builder
    {
        private Student s = new();
        public void BuildName(string Name, string Surname)
        {
            s.Name = Name;
            s.Surname = Surname;
        }
        public void BuildUniversity(University Univ)
        {
            s.Univ = Univ;
            Univ.AddStudent(s);
        }
        public void BuildBudget(bool budget)
        {
            if (budget) s.Form = "Budget";
            else s.Form = "Contract";
        }
        public void BuildDegree()
        {
            s.Degree = Degrees.Bachelor;
        }
        public void BuildYearOfAdmission()
        {
            s.YearOfAdmission = DateTime.Now.Year;
        }
        public void BuildYearOfEnd()
        {
            s.YearOfEnd = s.YearOfAdmission + 4;
        }
        public Student GetResult()
        {
            Student result = s;
            s = new();
            return result;
        }
    }

    class MasterBuilder : Builder
    {
        private Student s = new();
        public void BuildName(string Name, string Surname)
        {
            s.Name = Name;
            s.Surname = Surname;
        }
        public void BuildUniversity(University Univ)
        {
            s.Univ = Univ;
            Univ.AddStudent(s);
        }
        public void BuildBudget(bool budget)
        {
            if (budget) s.Form = "Budget";
            else s.Form = "Contract";
        }
        public  void BuildDegree()
        {
            s.Degree = Degrees.Master;
        }
        public void BuildYearOfAdmission()
        {
            s.YearOfAdmission = DateTime.Now.Year;
        }
        public void BuildYearOfEnd()
        {
            s.YearOfEnd = s.YearOfAdmission + 2;
        }
        public Student GetResult()
        {
            Student result = s;
            s = new();
            return result;
        }
    }

    class PhDBuilder : Builder
    {
        private Student s = new();
        public void BuildName(string Name, string Surname)
        {
            s.Name = Name;
            s.Surname = Surname;
        }
        public void BuildUniversity(University Univ)
        {
            s.Univ = Univ;
            Univ.AddStudent(s);
        }
        public void BuildBudget(bool budget)
        {
            if (budget) s.Form = "Budget";
            else s.Form = "Contract";
        }
        public void BuildDegree()
        {
            s.Degree = Degrees.PhD;
        }
        public void BuildYearOfAdmission()
        {
            s.YearOfAdmission = DateTime.Now.Year;
        }
        public void BuildYearOfEnd()
        {
            s.YearOfEnd = s.YearOfAdmission + 4;
        }
        public Student GetResult()
        {
            Student result = s;
            s = new();
            return result;
        }
    }
}
