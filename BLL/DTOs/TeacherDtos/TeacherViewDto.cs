using DAL.Entities;

namespace BLL.DTOs.TeacherDtos;

public class TeacherViewDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;

    public static implicit operator TeacherViewDto(Teacher teacher)
        => new TeacherViewDto()
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            BirthDate = teacher.BirthDate,
            PhoneNumber = teacher.PhoneNumber
        };
}