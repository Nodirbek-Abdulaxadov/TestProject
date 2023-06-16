using BLL.DTOs.StudentDtos;

namespace BLL.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllAsync();
    Task<IEnumerable<StudentDto>> Filter(string? searchText,
                                         OperatorCode? operatorCode,
                                         DateTime? startDate,
                                         DateTime? endDate,
                                         int? startAge = 0,
                                         int? endAge = 0);
    Task<StudentDto> GetByIdAsync(int id);
    Task AddAsync(AddStudentDto dto);
    Task UpdateAsync(UpdateStudentDto dto);
    Task RemoveAsync(int id);
}