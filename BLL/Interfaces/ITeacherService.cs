using BLL.DTOs.TeacherDtos;

namespace BLL.Interfaces;

public interface ITeacherService
{
    Task<IEnumerable<TeacherDto>> GetAllAsync();
    Task<IEnumerable<TeacherDto>> Filter(string? searchText,
                                         OperatorCode? operatorCode,
                                         DateTime? startDate,
                                         DateTime? endDate,
                                         int? startAge = 0,
                                         int? endAge = 0);
    Task<TeacherDto> GetByIdAsync(int id);
    Task AddAsync(AddTeacherDto dto);
    Task UpdateAsync(UpdateTeacherDto dto);
    Task RemoveAsync(int id);
}