using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Base;

public class BaseUser : BaseEntity
{
    [Required, StringLength(60)]
    public string FirstName { get; set; } = string.Empty;
    [Required, StringLength(60)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateOnly BirthDate { get; set; }
    [Required, StringLength(15)]
    public string PhoneNumber { get; set; }
}