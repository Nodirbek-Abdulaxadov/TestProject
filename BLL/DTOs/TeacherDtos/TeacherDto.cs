using BLL.DTOs.SubjectDtos;
using DAL.Entities;

namespace BLL.DTOs.TeacherDtos;

public class TeacherDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public List<SubjectDto> Subjects = new();

    public static implicit operator TeacherDto(Teacher teacher)
        => new TeacherDto()
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            BirthDate = teacher.BirthDate,
            PhoneNumber = teacher.PhoneNumber,
            Subjects = teacher.TeacherSubjects.Select(i => (SubjectDto)i.Subject)
                                              .ToList()
        };
}