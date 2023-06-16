using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.SubjectDtos;

public class UpdateSubjectDto : BaseDto
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;


    public static implicit operator Subject(UpdateSubjectDto subject)
        => new Subject()
        {
            Id = subject.Id,
            Name = subject.Name
        };
}