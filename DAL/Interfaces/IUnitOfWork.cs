namespace DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ITeacher Teachers { get; }
    IStudent Students { get; }
    ISubject Subjects { get; }

    Task SaveAsync();
}