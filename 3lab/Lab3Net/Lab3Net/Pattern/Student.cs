
namespace Lab3Net.Pattern
{
    enum Degrees
    {
        Bachelor,
        Master,
        PhD
    }
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public University Univ { get; set; }
        public string Form { get; set; }
        public Degrees Degree { get; set; }
        public int YearOfAdmission { get; set; }
        public int YearOfEnd { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Form of education: {Form}, " +
                   $"University: {Univ.Name}, Degree: {Degree}, " +
                   $"Year of admission: {YearOfAdmission}, Year of end: {YearOfEnd}";
        }
    }
}
