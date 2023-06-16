using DAL.Entities.MTM;

public class StudentSubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Score { get; set; }

    public static implicit operator StudentSubjectDto(StudentSubject studentSubject)
            => new StudentSubjectDto()
            {
                Id = studentSubject.Id,
                Name = studentSubject.Subject.Name,
                Score = studentSubject.Score
            };
}