namespace Cwiczenia3.Models.Student
{
    public class IdLessStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }

        public IdLessStudent() { }

        public IdLessStudent(string FirstName, string LastName, string IndexNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.IndexNumber = IndexNumber;
        }
    }
}
