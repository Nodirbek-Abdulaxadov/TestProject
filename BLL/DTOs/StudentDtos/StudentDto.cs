using BLL.DTOs.StudentDtos;
using BLL.DTOs.SubjectDtos;
using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.StudentDtos;

public class StudentDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;

    public List<StudentSubjectDto> Subjects = new();

    public static implicit operator StudentDto(Student student)
        => new StudentDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            BirthDate = student.BirthDate,
            PhoneNumber = student.PhoneNumber,
            Subjects = student.StudentSubjects.Select(i => (StudentSubjectDto)i)
                                              .ToList()
        };
}