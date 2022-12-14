using Library.Student.Domain.Entities;

namespace Library.Student.Domain.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<StudentItem>> GetAllStudentAsync();
}
