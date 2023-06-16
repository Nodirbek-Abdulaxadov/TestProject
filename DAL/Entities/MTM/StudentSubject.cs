using DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.MTM;

public class StudentSubject : BaseEntity
{
    [Required]
    public int StudentId { get; set; }
    public Student Student { get; set; }

    [Required]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    [Required]
    public float Score { get; set; } = 0;
}