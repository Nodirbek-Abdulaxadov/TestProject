using BLL.DTOs.StudentDtos;
using BLL.DTOs.SubjectDtos;
using BLL.DTOs.TeacherDtos;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class SubjectService : ISubjectService
{
    private readonly IUnitOfWork _unitOfWork;

    public SubjectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(AddSubjectDto dto)
    {
        await _unitOfWork.Subjects.AddAsync((Subject)dto);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<SubjectDto>> GetAllAsync()
    {
        var subjects = await _unitOfWork.Subjects.GetAllAsync();
        var subjectDtos = subjects.Select(s => (SubjectDto)s);
        var result = new List<SubjectDto>();

        foreach (var subject in subjectDtos)
        {
            subject.StudentsCount = (await _unitOfWork.Students.GetAllAsync())
                .Where(s => s.StudentSubjects.Any(i => i.SubjectId == subject.Id))
                .Select(s => (StudentViewDto)s)
                .Count();
            subject.TeachersCount = (await _unitOfWork.Teachers.GetAllAsync())
                .Where(t => t.TeacherSubjects.Any(i => i.SubjectId == subject.Id))
                .Select(t => (TeacherViewDto)t)
                .Count();

            result.Add(subject);
        }

        return result;
    }

    public async Task<SubjectDto> GetByIdAsync(int id)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(id);
        return (SubjectDto)subject;
    }

    public async Task RemoveAsync(int id)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(id);
        if (subject == null)
        {
            throw new ArgumentNullException(nameof(subject));
        }

        await _unitOfWork.Subjects.RemoveAsync(subject);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(UpdateSubjectDto dto)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(dto.Id);
        if (subject == null)
        {
            throw new ArgumentNullException(nameof(subject));
        }

        await _unitOfWork.SaveAsync();
        await _unitOfWork.Subjects.UpdateAsync((Subject)dto);
        await _unitOfWork.SaveAsync();
    }
}