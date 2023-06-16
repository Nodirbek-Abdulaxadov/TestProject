using DAL.Entities.Base;
using DAL.Entities.MTM;

namespace DAL.Entities;

public class Teacher : BaseUser 
{
    public List<TeacherSubject> TeacherSubjects = new();
}