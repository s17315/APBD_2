using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia3.DAL;
using Cwiczenia3.Models.Student;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDBService _dbService;

        public StudentsController(IDBService dBService)
        {
            _dbService = dBService;
        }

        [HttpGet]
        public IActionResult GetStudents(OrderStudentBy orderBy)
        {
            switch (orderBy)
            {
                case OrderStudentBy.ID_STUDENT:
                case OrderStudentBy.FIRST_NAME:
                case OrderStudentBy.LAST_NAME:
                case OrderStudentBy.INDEX_NUMBER:
                    return Ok(_dbService.GetStudents(orderBy));
            }

            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            Student student = _dbService.GetStudent(id);

            if (student != null)
            {
                return Ok(student);
            }

            return NotFound("Student not found");
        }

        [HttpPost]
        public IActionResult CreateStudent(IdLessStudent idLessStudent)
        {
            Student student = _dbService.AddStudent(idLessStudent);

            if (student != null)
            {
                return Ok(student);
            }

            return NotFound("Could not add student");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, IdLessStudent idLessStudent)
        {
            Student student = _dbService.UpdateStudent(id, idLessStudent);

            if (student != null)
            {
                return Ok("Update done");
            }

            return NotFound("Student not found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (_dbService.RemoveStudent(id))
            {
                return Ok("Delete done");
            }


            return NotFound("Student not found");
        }
    }
}