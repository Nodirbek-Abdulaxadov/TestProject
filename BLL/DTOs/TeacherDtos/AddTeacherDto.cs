using BLL.DTOs.SubjectDtos;
using DAL.Entities;
using DAL.Entities.MTM;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.TeacherDtos;

public class AddTeacherDto
{
    [Required, StringLength(60)]
    public string FirstName { get; set; } = string.Empty;
    [Required, StringLength(60)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
    [Required, StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    public List<SubjectDto> TeacherSubjects = new();


    public static implicit operator Teacher(AddTeacherDto teacher)
        => new Teacher()
        {
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            BirthDate = new DateOnly(teacher.BirthDate.Year,
                                     teacher.BirthDate.Month,
                                     teacher.BirthDate.Day),
            PhoneNumber = teacher.PhoneNumber,
            TeacherSubjects = teacher.TeacherSubjects.Select(s =>
                                      new TeacherSubject()
                                      {
                                          SubjectId = s.Id
                                      }).ToList()
        };
}