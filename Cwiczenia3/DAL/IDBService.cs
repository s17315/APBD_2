using Cwiczenia3.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.DAL
{
    public interface IDBService
    {
        public IEnumerable<Student> GetStudents();
        public IEnumerable<Student> GetStudents(OrderStudentBy orderBy);
        public Student GetStudent(int studentId);
        public Student AddStudent(IdLessStudent idLessStudent);
        public Student AddStudent(Student idLessStudent);
        public bool StudentExists(int studentId);
        public bool RemoveStudent(int studentId);
        public Student UpdateStudent(int studentId, IdLessStudent idLessStudent);
    }
}
