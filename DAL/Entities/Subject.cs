using DAL.Entities.Base;
using DAL.Entities.MTM;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class Subject : BaseEntity
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public List<TeacherSubject> SubjectTeachers = new();
    public List<StudentSubject> SubjectStudents = new();
}