using Library.Student.Domain.Entities;
using Library.Student.Domain.Repositories;

namespace Library.Student.Infrastructure.Data.Repositories;

public class StudentRepository : IStudentRepository
{
    public StudentRepository()
    {
    }
    public async Task<IEnumerable<StudentItem>> GetAllStudentAsync()
    {
        return new List<StudentItem>()
        {
            new StudentItem
            {
                Id = Guid.NewGuid(),
                Name = "Student One",
                Email = "studet.one@domain.com"
            },
            new StudentItem
            {
                Id = Guid.NewGuid(),
                Name = "Student Two",
                Email = "studet.two@domain.com"
            },
            new StudentItem
            {
                Id = Guid.NewGuid(),
                Name = "Student Three",
                Email = "studet.three@domain.com"
            }
        };
    }
}
