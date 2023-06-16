using BLL.DTOs.SubjectDtos;
using DAL.Entities;
using DAL.Entities.MTM;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.StudentDtos;

public class AddStudentDto
{
    [Required, StringLength(60)]
    public string FirstName { get; set; } = string.Empty;
    [Required, StringLength(60)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
    [Required, StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;
    public List<SubjectDto> StudentSubjects = new();

    public static implicit operator Student(AddStudentDto student)
        => new Student()
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            BirthDate = new DateOnly(student.BirthDate.Year, 
                                     student.BirthDate.Month,
                                     student.BirthDate.Day),
            PhoneNumber = student.PhoneNumber,
            StudentSubjects = student.StudentSubjects.Select(s => 
                                      new StudentSubject()
                                      {
                                          SubjectId = s.Id
                                      }).ToList()
        };
}