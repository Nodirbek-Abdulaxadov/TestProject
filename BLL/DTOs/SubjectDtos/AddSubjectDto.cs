using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs.SubjectDtos;

public class AddSubjectDto
{
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public static explicit operator Subject(AddSubjectDto dto)
        => new Subject() { Name = dto.Name };
}