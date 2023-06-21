using BLL.DTOs.StudentDtos;
using BLL.DTOs.TeacherDtos;
using DAL.Entities;

namespace BLL.DTOs.SubjectDtos;

public class SubjectDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public int StudentsCount { get; set; }
    public int TeachersCount { get; set; }
 
    public static implicit operator SubjectDto(Subject subject)
        => new SubjectDto()
        {
            Id = subject.Id,
            Name = subject.Name
        };
}