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
                Id = Guid.Parse("3673a9fd-191a-479c-a41f-3dc5611aa77d"),
                Name = "Student One",
                Email = "studet.one@domain.com"
            },
            new StudentItem
            {
                Id = Guid.Parse("4673a9fd-191a-479c-a41f-3dc5611aa77d"),
                Name = "Student Two",
                Email = "studet.two@domain.com"
            },
            new StudentItem
            {
                Id = Guid.Parse("5673a9fd-191a-479c-a41f-3dc5611aa77d"),
                Name = "Student Three",
                Email = "studet.three@domain.com"
            }
        };
    }
}
