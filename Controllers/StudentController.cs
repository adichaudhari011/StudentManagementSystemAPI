using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StuentMangementSys.Models;
using StuentMangementSys.Services.Interfaces;

namespace StuentMangementSys.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _service.GetAllStudents());
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await _service.AddStudent(student);

            return Ok("Student added successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            await _service.UpdateStudent(student);

            return Ok("Student updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _service.DeleteStudent(id);

            return Ok("Student deleted successfully");
        }
    }
}
