using Cwiczenia3.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.DAL
{
    public class MockDbService : IDBService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students =  new List<Student>() {
                new Student("B", "A", "0"),
                new Student("A", "C", "23"),
                new Student("C", "D", "22"),
                new Student("D", "B", "2"),
                new Student("E", "F", "12")
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public IEnumerable<Student> GetStudents(OrderStudentBy orderBy)
        {
            switch (orderBy)
            {
                case OrderStudentBy.ID_STUDENT:
                    return _students.OrderBy(s => s.IdStudent);
                case OrderStudentBy.FIRST_NAME:
                    return _students.OrderBy(s => s.FirstName);
                case OrderStudentBy.LAST_NAME:
                    return _students.OrderBy(s => s.LastName);
                case OrderStudentBy.INDEX_NUMBER:
                    return _students.OrderBy(s => s.IndexNumber);
            }

            return GetStudents();
        }

        public Student GetStudent(int studentId)
        {
            if (StudentExists(studentId))
            {
                return _students.Where(s => s.IdStudent == studentId).First();
            }

            return null;
        }

        public Student AddStudent(IdLessStudent idLessStudent)
        {
            return AddStudent(new Student(idLessStudent));
        }
        public Student AddStudent(Student student)
        {
            _students = _students.Append(student);
            return student;
        }

        public bool RemoveStudent(int studentId)
        {
            if (StudentExists(studentId))
            {
                _students = _students.Where(s => s.IdStudent != studentId);
                return true;
            }

            return false;
        }

        public bool StudentExists(int studentId)
        {
            return _students.Any(s => s.IdStudent == studentId);
        }

        public Student UpdateStudent(int studentId, IdLessStudent idLessStudent)
        {
            if (StudentExists(studentId))
            {
                if (RemoveStudent(studentId))
                {
                    return AddStudent(new Student(studentId, idLessStudent));
                }
            }

            return null;
        }
    }
}
