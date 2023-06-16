using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Base;

public class BaseEntity
{
    [Key, Required]
    public int Id { get; set; }
}