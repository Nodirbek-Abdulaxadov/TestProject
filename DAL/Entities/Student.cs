using DAL.Entities.Base;
using DAL.Entities.MTM;

namespace DAL.Entities;

public class Student : BaseUser 
{
    public List<StudentSubject> StudentSubjects = new();
}