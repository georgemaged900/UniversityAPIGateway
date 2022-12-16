using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using UniversityAPIGateway.BLL;
using UniversityAPIGateway.Models;


namespace UniversityAPIGateway.Controllers
{


    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : Controller
    {

        StudentBLL studentBLL = new StudentBLL();


        [HttpGet(Name = "GetAllStudent")]
        public List<Student> GetAllStudent()
        {

            return studentBLL.GetAllStudent();          

        }

       /* [HttpPost(Name = "AddStudent")]
        public string AddStudentt(Student student)
        {


           string response = studentBLL.AddStudent(student);
           var json  = JsonConvert.SerializeObject(response);
           var jsonStr = json.ToString();
           return jsonStr;

           


        }*/



        [HttpPost(Name = "AddStudent")]
        public async Task<string> AddStudent(Student student)
        {


            var response = await studentBLL.AddStudent(student);
            var json = JsonConvert.SerializeObject(response);
            var jsonStr = json.ToString();
            //return BadRequest(jsonStr);



            return jsonStr;
            


        }

        [HttpGet]

        public async Task<IActionResult>test()
        {
 

            return BadRequest();
        }


    }
}
