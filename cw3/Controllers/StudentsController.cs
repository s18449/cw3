using cw3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public string GetStudent(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //...add to database
            //...generating index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut]
        public IActionResult UpdateStudent(string studentId)
        {
            return Ok("Aktualizacja studenta o id " + studentId + " dokończona");
        }

        [HttpDelete]
        public IActionResult DeleteStudent(string studentId)
        {
            return Ok("Usuwanie studenta o id " + studentId + " ukończone");
        }

    }
}
