using Microsoft.EntityFrameworkCore.Update.Internal;
using StudentAdmissionAppApi.Data.Contract;
using StudentAdmissionAppApi.Data.Implementation;
using StudentAdmissionAppApi.Dtos;
using StudentAdmissionAppApi.Models;
using StudentAdmissionAppApi.Service.Contract;

namespace StudentAdmissionAppApi.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public ServiceResponse<string> AddStudent(Students student)
        {
            var response = new ServiceResponse<string>();
            if (student == null)
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
                return response;
            }
  
            if (student.DateOfApplication > DateTime.Now)
            {
                response.Success = false;
                response.Message = "Please enter proper admission date";
                return response;
            }
            if (student.StageId == 1 || student.StageId == 2)
            {

                student.TotalMarks = student.Maths + student.Hindi + student.SocialStudies + student.Science + student.English;
                student.Percentages = (student.TotalMarks / 500) * 100;
            }
            if (student.StageId == 3)
            {
                student.TotalMarks = student.Chemistry + student.Physics + student.Biology;
                student.Percentages = (student.TotalMarks / 300) * 100;
            }

            if (student.StageId == 1 && (student.Maths == 0 || student.Science == 0 || student.SocialStudies == 0 || student.Hindi == 0 || student.English == 0))
            {
                response.Success = false;
                response.Message = "Please enter marks";
                return response;
            }
            if (student.StageId == 2 && (student.Maths == 0 || student.Science == 0 || student.SocialStudies == 0 || student.Hindi == 0 || student.English == 0))
            {
                response.Success = false;
                response.Message = "Please enter marks";
                return response;
            }
            if (student.Gender.ToLower() != "m" && student.Gender.ToLower() != "f")
            {
                response.Success = false;
                response.Message = "Please enter Gender .";
                return response;
            }
            if (student.StageId == 3 && (student.Chemistry == 0 || student.Biology == 0 || student.Physics == 0))
            {
                response.Success = false;
                response.Message = "Please enter marks";
                return response;
            }
          
            var result = _studentRepository.AddStudent(student);
            response.Success = result;
            response.Message = result ? "Student added successfully." : "Something went wrong. Please try after sometime.";
            return response;
        }


        public ServiceResponse<IEnumerable<StudentDto>> AllStudents()
        {

            var response = new ServiceResponse<IEnumerable<StudentDto>>();
            var students = _studentRepository.GetAllStudents();

            if (students != null && students.Any())
            {
                List<StudentDto> studentDtos = new List<StudentDto>();
                foreach (var student in students)
                {

                    studentDtos.Add(new StudentDto()
                    {
                        StudentId = student.StudentId,
                        StageId = student.StageId,
                        StandardId = student.StandardId,
                        StudentName = student.StudentName,
                        StudentEmail = student.StudentEmail,
                        IsPhysicallyDisabled = student.IsPhysicallyDisabled,
                        Gender = student.Gender,
                        DateOfApplication = student.DateOfApplication,
                        Image = student.Image,
                        Maths = student.Maths,
                        Science = student.Science,
                        SocialStudies = student.SocialStudies,
                        Hindi = student.Hindi,
                        English = student.English,
                        Chemistry = student.Chemistry,
                        Biology = student.Biology,
                        Physics = student.Physics,

                    });
                }
                response.Data = studentDtos;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found!";
            }
            return response;
        }


        public ServiceResponse<StudentDto> GetStudentById(int id)
        {
            var response = new ServiceResponse<StudentDto>();
            var student = _studentRepository.GetStudents(id);
            var studentDto = new StudentDto()
            {
                StudentId = student.StudentId,
                StageId = student.StageId,
                StandardId = student.StandardId,
                StudentName = student.StudentName,
                StudentEmail = student.StudentEmail,
                IsPhysicallyDisabled = student.IsPhysicallyDisabled,
                Gender = student.Gender,
                DateOfApplication = student.DateOfApplication,
                Image = student.Image,
                Maths = student.Maths,
                Science = student.Science,
                SocialStudies = student.SocialStudies,
                Hindi = student.Hindi,
                English = student.English,
                Chemistry = student.Chemistry,
                Biology = student.Biology,
                Physics = student.Physics,

            };
            response.Data = studentDto;
            return response;
        }

        /*public ServiceResponse<StudentDto> GetStudentById(int id)
        {
            
            var student = _studentRepository.GetStudents(id);

            if(student.StageId == 1 || student.StageId == 2)
            {
                var response = new ServiceResponse<FiveSubDto>();
                var studentDto = new FiveSubDto()
                {
                    StudentId = student.StudentId,
                    StageId = student.StageId,
                    StandardId = student.StandardId,
                    StudentName = student.StudentName,
                    StudentEmail = student.StudentEmail,
                    IsPhysicallyDisabled = student.IsPhysicallyDisabled,
                    Gender = student.Gender,
                    DateOfApplication = student.DateOfApplication,
                    Image = student.Image,
                    Maths = student.Maths,
                    Science = student.Science,
                    SocialStudies = student.SocialStudies,
                    Hindi = student.Hindi,
                    English = student.English,
                    
                };
                response.Data = studentDto;
            }
            else if (student.StageId == 3)
            {
                var response = new ServiceResponse<ThreeSubDto>();
                var studentDto = new ThreeSubDto()
                {
                    StudentId = student.StudentId,
                    StageId = student.StageId,
                    StandardId = student.StandardId,
                    StudentName = student.StudentName,
                    StudentEmail = student.StudentEmail,
                    IsPhysicallyDisabled = student.IsPhysicallyDisabled,
                    Gender = student.Gender,
                    DateOfApplication = student.DateOfApplication,
                    Image = student.Image,
                    Chemistry = student.Chemistry,
                    Biology = student.Biology,
                    Physics = student.Physics,
                };
                response.Data = studentDto;
                
            }
            
        }*/


        public ServiceResponse<string> UpdateStudents(Students students)
        {
            var response = new ServiceResponse<string>();
            if(students == null)
            {
                response.Success=false;
                response.Message = "Something went wrong. Please try after sometime.";
            }
            else if (AlreadyExists(students.StudentName))
            {
                response.Success = false;
                response.Message = "Student already exists.";
                return response;
            }
            var updateStudent = _studentRepository.GetStudents(students.StudentId);
            if(updateStudent != null)
            {
                updateStudent.StudentId = students.StudentId;
                updateStudent.StageId = students.StageId;
                updateStudent.StandardId = students.StandardId;
                updateStudent.StudentName = students.StudentName;
                updateStudent.StudentEmail = students.StudentEmail;
                updateStudent.IsPhysicallyDisabled = students.IsPhysicallyDisabled;
                updateStudent.Gender = students.Gender;
                updateStudent.DateOfApplication = students.DateOfApplication;
                updateStudent.Image = students.Image;
                updateStudent.Maths = students.Maths;
                updateStudent.Science = students.Science;
                updateStudent.SocialStudies = students.SocialStudies;
                updateStudent.Hindi = students.Hindi;
                updateStudent.English = students.English;
                updateStudent.Chemistry = students.Chemistry;
                updateStudent.Biology = students.Biology;
                updateStudent.Physics = students.Physics;
                
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
                return response;
            }
            return response;
        }


        private bool AlreadyExists(string name)
        {
            var result = false;
            var students = _studentRepository.GetAllStudentsByName(name);
            if(students != null)
            {
                result = true;
            }
            return result;
        }


        public ServiceResponse<IEnumerable<SP_StudentAdmissionResult>> StudentsCount()
        {
            var response = new ServiceResponse<IEnumerable<SP_StudentAdmissionResult>>();

            var student = _studentRepository.StudentAdmissionResults();

            if (student != null && student.Any())
            {
                response.Data = student;

            }
            else
            {
                response.Success = false;
                response.Message = "No records found";

            }
            return response;
        }


    }
}
