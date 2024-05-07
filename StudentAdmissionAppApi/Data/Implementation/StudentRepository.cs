using Microsoft.EntityFrameworkCore;
using StudentAdmissionAppApi.Data.Contract;
using StudentAdmissionAppApi.Models;

namespace StudentAdmissionAppApi.Data.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext _appDBContext;

        public StudentRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public bool AddStudent(Students students)
        {
            var result = false;
            if (students != null)
            {
                _appDBContext.Students.Add(students);
                _appDBContext.SaveChanges();
                result = true;
            }

            return result;
        }

        public IEnumerable<Students> GetAllStudents()
        {
            List<Students> students = _appDBContext.Students.Include(C=>C.Stage).Include(P=>P.Standard).ToList();
            return students;
        }


        public IEnumerable<Students> GetAllStudentsByName( string name)
        {
            List<Students> students = _appDBContext.Students.Where(C=> C.StudentName == name ).ToList();
            return students;
        }


        public Students GetStudents(int id)
        {
            var students = _appDBContext.Students.FirstOrDefault(c => c.StudentId == id);
            return students;
        }


        public bool UpdateStudent(Students students)
        {
            var result = false;
            if (students != null)
            {
                _appDBContext.Students.Update(students);
                _appDBContext.SaveChanges();
                result = true;
            }
            return result;
        }


        public IEnumerable<SP_StudentAdmissionResult> StudentAdmissionResults()
        {
            List<SP_StudentAdmissionResult> results = _appDBContext.Procedures.SP_StudentAdmission();

            List<SP_StudentAdmissionResult> students = results.Select(results => new SP_StudentAdmissionResult
            {
                stagename = results.stagename,
                standardname = results.standardname,
                totalstudent = results.totalstudent,

            }).ToList();

            return students;
        }


    }
}
