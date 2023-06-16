using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs;

public class BaseDto
{
    [Required]
    public int Id { get; set; }
}