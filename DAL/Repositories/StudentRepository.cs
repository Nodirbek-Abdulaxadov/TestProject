using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class StudentRepository : Repository<Student>, IStudent
{
    private readonly AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<IEnumerable<Student>> GetAllAsync()
    {
        var students = _dbContext.Students
                                 .Include(t => t.StudentSubjects)
                                 .ThenInclude(i => i.Subject)
                                 .AsEnumerable();

        return await Task.FromResult(students);
    }

    public override async Task<Student> GetByIdAsync(int id)
    {
        var student = _dbContext.Students
                                 .Include(t => t.StudentSubjects)
                                 .ThenInclude(i => i.Subject)
                                 .FirstOrDefault(s => s.Id == id);

        return await Task.FromResult(student);
    }
}