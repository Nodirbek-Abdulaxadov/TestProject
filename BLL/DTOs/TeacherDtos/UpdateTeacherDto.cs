using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.TeacherDtos;

public class UpdateTeacherDto : BaseDto
{
    [Required, StringLength(60)]
    public string FirstName { get; set; } = string.Empty;
    [Required, StringLength(60)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
    [Required, StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    public static implicit operator Teacher(UpdateTeacherDto teacher)
        => new Teacher()
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            BirthDate = new DateOnly(teacher.BirthDate.Year,
                                     teacher.BirthDate.Month,
                                     teacher.BirthDate.Day),
            PhoneNumber = teacher.PhoneNumber
        };
}