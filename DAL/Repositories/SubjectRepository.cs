using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DAL.Repositories;

public class SubjectRepository : Repository<Subject>, ISubject
{
    private readonly AppDbContext _dbContext;

    public SubjectRepository(AppDbContext dbContext) 
        : base(dbContext)
    {
        _dbContext = dbContext;
    }
}