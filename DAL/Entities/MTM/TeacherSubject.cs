using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DAL.Entities.Base;

namespace DAL.Entities.MTM;

public class TeacherSubject : BaseEntity
{
    [Required]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    [Required]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}