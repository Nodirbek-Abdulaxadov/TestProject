using BLL.DTOs.SubjectDtos;

namespace BLL.Interfaces; 
public interface ISubjectService 
{
    Task<IEnumerable<SubjectDto>> GetAllAsync();
    Task<SubjectDto> GetByIdAsync(int id);
    Task AddAsync(AddSubjectDto dto);
    Task UpdateAsync(UpdateSubjectDto dto);
    Task RemoveAsync(int id);
}