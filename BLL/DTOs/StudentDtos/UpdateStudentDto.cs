using DAL.Entities;
using DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.StudentDtos;

public class UpdateStudentDto : BaseDto
{
    [Required, StringLength(60)]
    public string FirstName { get; set; } = string.Empty;
    [Required, StringLength(60)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
    [Required, StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    public static implicit operator Student(UpdateStudentDto student)
        => new Student()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            BirthDate = new DateOnly(student.BirthDate.Year,
                                     student.BirthDate.Month,
                                     student.BirthDate.Day),
            PhoneNumber = student.PhoneNumber
        };
}