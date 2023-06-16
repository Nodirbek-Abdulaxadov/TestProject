using BLL.DTOs.TeacherDtos;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;

    public TeacherService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(AddTeacherDto dto)
    {
        await _unitOfWork.Teachers.AddAsync((Teacher)dto);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<TeacherDto>> Filter(string? searchText,
                                                OperatorCode? operatorCode,
                                                DateTime? startDate, DateTime? endDate,
                                                int? startAge = 0, int? endAge = 0)
    {
        var teachers = await GetAllAsync();

        // filter by text
        if (!string.IsNullOrEmpty(searchText))
        {
            teachers = teachers.Where(t => t.FirstName.ToLower()
                                                      .Contains(searchText.ToLower()) ||
                                           t.LastName.ToLower()
                                                      .Contains(searchText.ToLower()));
        }

        //filter by birthDate
        if (startDate != null)
        {
            teachers = teachers.Where(t =>
                t.BirthDate >= new DateOnly(startDate.Value.Year,
                                            startDate.Value.Month,
                                            startDate.Value.Day));
        }
        if (endDate != null)
        {
            teachers = teachers.Where(t =>
                t.BirthDate <= new DateOnly(endDate.Value.Year,
                                            endDate.Value.Month,
                                            endDate.Value.Day));
        }

        //filter by age
        int currentYear = DateTime.Now.Year;
        if (startAge != 0)
        {
            teachers = teachers.Where(t => currentYear - t.BirthDate.Year >= startAge);
        }
        if (endAge != 0)
        {
            teachers = teachers.Where(t => currentYear - t.BirthDate.Year <= endAge);
        }

        //filter by operator code
        switch (operatorCode)
        {
            case OperatorCode.Beeline:
                {
                    teachers = teachers.Where(t => t.PhoneNumber.StartsWith("+99890") ||
                                                   t.PhoneNumber.StartsWith("+99891"));
                }
                break;
            case OperatorCode.Uzmobile:
                {
                    teachers = teachers.Where(t => t.PhoneNumber.StartsWith("+99899") ||
                                                   t.PhoneNumber.StartsWith("+99895"));
                }
                break;
            case OperatorCode.Ucell:
                {
                    teachers = teachers.Where(t => t.PhoneNumber.StartsWith("+99893") ||
                                                   t.PhoneNumber.StartsWith("+99894") ||
                                                   t.PhoneNumber.StartsWith("+99850"));
                }
                break;
            case OperatorCode.Humans:
                {
                    teachers = teachers.Where(t => t.PhoneNumber.StartsWith("+99833"));
                }
                break;
            case OperatorCode.MobiUz:
                {
                    teachers = teachers.Where(t => t.PhoneNumber.StartsWith("+99897") ||
                                                   t.PhoneNumber.StartsWith("+99888"));
                }
                break;
            case OperatorCode.Perfectum:
                {
                    teachers = teachers.Where(t => t.PhoneNumber.StartsWith("+99898"));
                }
                break;
        }

        return teachers;
    }

    public async Task<IEnumerable<TeacherDto>> GetAllAsync()
    {
        var teachers = await _unitOfWork.Teachers.GetAllAsync();
        return teachers.Select(t => (TeacherDto)t);
    }

    public async Task<TeacherDto> GetByIdAsync(int id)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
        return (TeacherDto)teacher;
    }

    public async Task RemoveAsync(int id)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
        if (teacher != null)
        {
            throw new ArgumentNullException(nameof(teacher));
        }

        await _unitOfWork.Teachers.RemoveAsync(teacher);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(UpdateTeacherDto dto)
    {
        var teacher = await _unitOfWork.Teachers.GetByIdAsync(dto.Id);
        if (teacher != null)
        {
            throw new ArgumentNullException(nameof(teacher));
        }

        await _unitOfWork.Teachers.UpdateAsync((Teacher)dto);
        await _unitOfWork.SaveAsync();
    }
}