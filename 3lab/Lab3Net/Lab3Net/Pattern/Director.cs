
namespace Lab3Net.Pattern
{
    class Director
    {
        public Student ConstructBudget(Builder builder, string Name, string Surname, University Univ)
        {
            builder.BuildName(Name, Surname);
            builder.BuildUniversity(Univ);
            builder.BuildBudget(true);
            builder.BuildDegree();
            builder.BuildYearOfAdmission();
            builder.BuildYearOfEnd();
            return builder.GetResult();
        }
        public Student ConstructContract(Builder builder, string Name, string Surname, University Univ)
        {
            builder.BuildName(Name, Surname);
            builder.BuildUniversity(Univ);
            builder.BuildBudget(false);
            builder.BuildDegree();
            builder.BuildYearOfAdmission();
            builder.BuildYearOfEnd();
            return builder.GetResult();
        }
    }
}
