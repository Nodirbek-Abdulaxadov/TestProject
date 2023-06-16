using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TeacherRepository : Repository<Teacher>, ITeacher
{
    private readonly AppDbContext _dbContext;

    public TeacherRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        var teachers = _dbContext.Teachers
                                 .Include(t => t.TeacherSubjects)
                                 .ThenInclude(i => i.Subject)
                                 .AsEnumerable();

        return await Task.FromResult(teachers);
    }

    public override async Task<Teacher> GetByIdAsync(int id)
    {
        var teacher = _dbContext.Teachers
                                 .Include(t => t.TeacherSubjects)
                                 .ThenInclude(i => i.Subject)
                                 .FirstOrDefault(s => s.Id == id);

        return await Task.FromResult(teacher);
    }
}