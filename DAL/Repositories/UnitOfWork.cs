using DAL.Interfaces;

namespace DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext,
                        ITeacher teacherInterface,
                        IStudent studentInterface,
                        ISubject subjectInterface)
    {
        _dbContext = dbContext;
        Teachers = teacherInterface;
        Students = studentInterface;
        Subjects = subjectInterface;
    }

    public ITeacher Teachers { get; }

    public IStudent Students { get; }

    public ISubject Subjects { get; }

    public void Dispose()
        => GC.SuppressFinalize(this);

    public async Task SaveAsync()
        => await _dbContext.SaveChangesAsync();
}