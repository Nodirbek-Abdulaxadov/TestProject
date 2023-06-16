using DAL.Entities;

namespace DAL.Interfaces;

public interface ITeacher : IRepository<Teacher>
{
    Task<IEnumerable<Teacher>> GetAllAsync();
}