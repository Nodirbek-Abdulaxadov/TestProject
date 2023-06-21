using DAL.Entities;

namespace BLL.DTOs.StudentDtos;

public class StudentViewDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;

    public static implicit operator StudentViewDto(Student student)
        => new StudentViewDto()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            BirthDate = student.BirthDate,
            PhoneNumber = student.PhoneNumber
        };
}