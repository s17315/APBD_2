using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia3.Models.Student;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>() {
            new Student("B", "A", "0"), 
            new Student("A", "C", "23"),
            new Student("C", "D", "22"),
            new Student("D", "B", "2"),
            new Student("E", "F", "12")
        };

        [HttpGet]
        public IActionResult GetStudents(OrderStudentBy orderBy)
        {
            switch (orderBy)
            {
                case OrderStudentBy.ID_STUDENT:
                    return Ok(students.OrderBy(s => s.IdStudent));
                case OrderStudentBy.FIRST_NAME:
                    return Ok(students.OrderBy(s => s.FirstName));
                case OrderStudentBy.LAST_NAME:
                    return Ok(students.OrderBy(s => s.LastName));
                case OrderStudentBy.INDEX_NUMBER:
                    return Ok(students.OrderBy(s => s.IndexNumber));
            }

            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (students.Exists(s => s.IdStudent == id))
            {
                return Ok(students[id]);
            }

            return NotFound("Student not found");
        }

        [HttpPost]
        public IActionResult CreateStudent(IdLessStudent idLessStudent)
        {
            Student newStudent = new Student(idLessStudent);

            students.Add(newStudent);
            
            return Ok(newStudent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, IdLessStudent idLessStudent)
        {
            if (students.Exists(s => s.IdStudent == id))
            {
                students.RemoveAll(s => s.IdStudent == id);
                Student student = new Student(id, idLessStudent);
                students.Add(student);

                return Ok("Update done");
            }


            return NotFound("Student not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (students.Exists(s => s.IdStudent == id))
            {
                students.RemoveAll(s => s.IdStudent == id);

                return Ok("Delete done");
            }


            return NotFound("Student not found");
        }
    }
}