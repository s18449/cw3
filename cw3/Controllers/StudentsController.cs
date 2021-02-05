using cw3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private const string ConString = "Data Source=db-mssql;Initial Catalog=s18449;Integrated Security=True";

        [HttpGet]
        public IActionResult GetStudent()
        {
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(ConString)) 
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from students";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while(dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                }

                return Ok(list);

            }

        }

        [HttpGet("{idStudenta}")]
        public IActionResult GetStudent(string idStudenta)
        {

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select semestr from students where idstudy=@id";

                com.Parameters.AddWithValue("id", idStudenta);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    string Semestr = dr["Semester"].ToString();
                    
                    return Ok(Semestr);
                }

            }

            return NotFound();
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
