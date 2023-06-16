using BLL.DTOs.StudentDtos;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(AddStudentDto dto)
    {
        var student = await _unitOfWork.Students.AddAsync((Student)dto);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IEnumerable<StudentDto>> Filter(string? searchText, 
        OperatorCode? operatorCode, DateTime? startDate, 
        DateTime? endDate, int? startAge = 0, int? endAge = 0)
    {
        var students  = await GetAllAsync();

        // filter by text
        if (!string.IsNullOrEmpty(searchText))
        {
            students = students.Where(t => t.FirstName.ToLower()
                                                      .Contains(searchText.ToLower()) ||
                                           t.LastName.ToLower()
                                                      .Contains(searchText.ToLower()));
        }

        //filter by birthDate
        if (startDate != null)
        {
            students = students.Where(t => 
                t.BirthDate >= new DateOnly(startDate.Value.Year,
                                            startDate.Value.Month,
                                            startDate.Value.Day));
        }
        if (endDate != null)
        {
            students = students.Where(t => 
                t.BirthDate <= new DateOnly(endDate.Value.Year,
                                            endDate.Value.Month,
                                            endDate.Value.Day));
        }

        //filter by age
        int currentYear = DateTime.Now.Year;
        if (startAge != 0)
        {
            students = students.Where(t => currentYear - t.BirthDate.Year >= startAge);
        }
        if (endAge != 0)
        {
            students = students.Where(t => currentYear - t.BirthDate.Year <= endAge);
        }

        //filter by operator code
        switch (operatorCode)
        {
            case OperatorCode.Beeline:
                {
                    students = students.Where(t => t.PhoneNumber.StartsWith("+99890") ||
                                                   t.PhoneNumber.StartsWith("+99891"));
                }
                break;
            case OperatorCode.Uzmobile:
                {
                    students = students.Where(t => t.PhoneNumber.StartsWith("+99899") ||
                                                   t.PhoneNumber.StartsWith("+99895"));
                }
                break;
            case OperatorCode.Ucell:
                {
                    students = students.Where(t => t.PhoneNumber.StartsWith("+99893") ||
                                                   t.PhoneNumber.StartsWith("+99894") ||
                                                   t.PhoneNumber.StartsWith("+99850"));
                }
                break;
            case OperatorCode.Humans:
                {
                    students = students.Where(t => t.PhoneNumber.StartsWith("+99833"));
                }
                break;
            case OperatorCode.MobiUz:
                {
                    students = students.Where(t => t.PhoneNumber.StartsWith("+99897") ||
                                                       t.PhoneNumber.StartsWith("+99888"));
                }
                break;
            case OperatorCode.Perfectum:
                {
                    students = students.Where(t => t.PhoneNumber.StartsWith("+99898"));
                }
                break;
        }

        return students;
    }

    public async Task<IEnumerable<StudentDto>> GetAllAsync()
    {
        var students = await _unitOfWork.Students.GetAllAsync();
        return students.Select(s => (StudentDto)s);
    }

    public async Task<StudentDto> GetByIdAsync(int id)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(id);
        return (StudentDto)student;
    }

    public async Task RemoveAsync(int id)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(id);
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        await _unitOfWork.Students.RemoveAsync(student);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateAsync(UpdateStudentDto dto)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(dto.Id);
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        await _unitOfWork.Students.UpdateAsync(student);
        await _unitOfWork.SaveAsync();
    }
}