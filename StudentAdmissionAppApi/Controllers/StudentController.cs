using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdmissionAppApi.Dtos;
using StudentAdmissionAppApi.Models;
using StudentAdmissionAppApi.Service.Contract;
using StudentAdmissionAppApi.Service.Implementation;

namespace StudentAdmissionAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            var response = _studentService.AllStudents();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }



        [HttpGet("GetStudentById")]
        
        public IActionResult GetStudentsById(int id)
        {
            var response = _studentService.GetStudentById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpPost("AddStudent")]
        public IActionResult AddProduct(AddStudentDto addStudent)
        {
            
            var student = new Students
            {
                StageId = addStudent.StageId,
                StandardId = addStudent.StandardId,
                StudentName = addStudent.StudentName,
                StudentEmail = addStudent.StudentEmail,
                IsPhysicallyDisabled = addStudent.IsPhysicallyDisabled,
                Gender = addStudent.Gender,
                DateOfApplication = addStudent.DateOfApplication,
                Image = addStudent.Image,
                Maths = addStudent.Maths,
                Science = addStudent.Science,
                SocialStudies = addStudent.SocialStudies,
                Hindi = addStudent.Hindi,
                English = addStudent.English,
                Chemistry = addStudent.Chemistry,
                Biology = addStudent.Biology,
                Physics = addStudent.Physics,
            };

            var result = _studentService.AddStudent(student);
            return !result.Success ? BadRequest(result) : Ok(result);
        }

        [HttpPut("UpdateStudent")]

        public IActionResult UpdateStudent(UpdateStudentDto updateStudentDto)
        {
            var student = new Students()
            {
                StudentId= updateStudentDto.StudentId,
                StageId = updateStudentDto.StageId,
                StandardId = updateStudentDto.StandardId,
                StudentName = updateStudentDto.StudentName,
                StudentEmail = updateStudentDto.StudentEmail,
                IsPhysicallyDisabled = updateStudentDto.IsPhysicallyDisabled,
                Gender = updateStudentDto.Gender,
                DateOfApplication = updateStudentDto.DateOfApplication,
                Image = updateStudentDto.Image,
                Maths = updateStudentDto.Maths,
                Science = updateStudentDto.Science,
                SocialStudies = updateStudentDto.SocialStudies,
                Hindi = updateStudentDto.Hindi,
                English = updateStudentDto.English,
                Chemistry = updateStudentDto.Chemistry,
                Biology = updateStudentDto.Biology,
                Physics = updateStudentDto.Physics,
            };

            var response = _studentService.UpdateStudents(student);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }



        [HttpGet("GetAdmissionReport")]

        public IActionResult GetAdmissionResult()
        {
            var response = _studentService.StudentsCount();
            if (!response.Success)
            {
                return BadRequest();

            }
            return Ok(response);
        }


    }
}
