using StuentMangementSys.Models;
using StuentMangementSys.Repositories.Interfaces;
using StuentMangementSys.Services.Interfaces;

namespace StuentMangementSys.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _repository.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _repository.GetStudentById(id);
        }

        public async Task AddStudent(Student student)
        {
            student.CreatedDate = DateTime.Now;

            await _repository.AddStudent(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _repository.UpdateStudent(student);
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _repository.GetStudentById(id);

            if (student == null)
            {
                throw new Exception("Student not found");
            }

            await _repository.DeleteStudent(student);
        }
    }
}
