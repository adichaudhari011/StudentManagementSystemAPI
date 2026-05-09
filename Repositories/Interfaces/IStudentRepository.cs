using StuentMangementSys.Models;
namespace StuentMangementSys.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();

        Task<Student> GetStudentById(int id);

        Task AddStudent(Student student);

        Task UpdateStudent(Student student);

        Task DeleteStudent(Student student);
    }
}
