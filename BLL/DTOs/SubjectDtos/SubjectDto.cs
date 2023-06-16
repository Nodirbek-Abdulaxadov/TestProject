using DAL.Entities;

namespace BLL.DTOs.SubjectDtos;

public class SubjectDto : BaseDto
{
    public string Name { get; set; } = string.Empty;


    public static implicit operator SubjectDto(Subject subject)
        => new SubjectDto()
        {
            Id = subject.Id,
            Name = subject.Name
        };
}