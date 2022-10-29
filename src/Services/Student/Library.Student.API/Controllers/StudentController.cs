using Library.Student.Domain.Entities;
using Library.Student.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Student.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Route("/api/v1/students")]
    public async Task<ActionResult<IEnumerable<StudentItem>>> GetAllStudents()
    {
        var students = await _studentRepository.GetAllStudentAsync();

        return Ok(students);
    }
}
