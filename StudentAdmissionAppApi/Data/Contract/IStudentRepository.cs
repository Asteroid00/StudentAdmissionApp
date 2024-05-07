using StudentAdmissionAppApi.Models;

namespace StudentAdmissionAppApi.Data.Contract
{
    public interface IStudentRepository
    {

        bool AddStudent(Students students);

        IEnumerable<Students> GetAllStudents();

        Students GetStudents(int id);

        bool UpdateStudent(Students students);

        IEnumerable<Students> GetAllStudentsByName(string name);

        IEnumerable<SP_StudentAdmissionResult> StudentAdmissionResults();
    }
}
