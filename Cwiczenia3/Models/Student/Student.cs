namespace Cwiczenia3.Models.Student
{
    public class Student : IdLessStudent
    {
        private static int ID_GENERATOR = 0;

        public int IdStudent { get; set; }

        public Student(IdLessStudent idLessS) : this(idLessS.FirstName, idLessS.LastName, idLessS.IndexNumber){ }

        public Student(int IdStudent, string FirstName, string LastName, string IndexNumber) : base(FirstName, LastName, IndexNumber)
        {
            this.IdStudent = IdStudent;
        }

        public Student(string FirstName, string LastName, string IndexNumber) : base(FirstName, LastName, IndexNumber)
        {
            this.IdStudent = ID_GENERATOR++;
        }

        public Student(int IdStudent, IdLessStudent idLessS) : this(IdStudent, idLessS.FirstName, idLessS.LastName, idLessS.IndexNumber) { }
    }
}
