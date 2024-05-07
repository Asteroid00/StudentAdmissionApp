using StudentAdmissionAppApi.Data.Contract;
using StudentAdmissionAppApi.Dtos;
using StudentAdmissionAppApi.Models;

namespace StudentAdmissionAppApi.Service.Contract
{
    public interface IStudentService
    {
        public ServiceResponse<string> AddStudent(Students students);
        public ServiceResponse<IEnumerable<StudentDto>> AllStudents();
        public ServiceResponse<StudentDto> GetStudentById(int id);
        public ServiceResponse<string> UpdateStudents(Students students);

        ServiceResponse<IEnumerable<SP_StudentAdmissionResult>> StudentsCount();

    }
}
