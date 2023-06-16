using BLL.DTOs.StudentDtos;
using BLL.DTOs.SubjectDtos;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PL.ViewModels;

namespace PL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
	{
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var students = await _studentService.GetAllAsync();
        var json = JsonConvert.SerializeObject(students, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

        return Ok(json);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var student = await _studentService.GetByIdAsync(id);
        var json = JsonConvert.SerializeObject(student, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

        return Ok(json);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] QueryFilter query)
    {
        var students = await _studentService.Filter(query.searchText,
                                                    query.operatorCode,
                                                    query.startDate, query.endDate,
                                                    query.startAge, query.endAge);
        return Ok(students);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] AddStudentDto dto, 
                                          [FromBody] List<AddStudentSubjectDto> subjects)
    {
        if (ModelState.IsValid)
        {
            dto.StudentSubjects = subjects;
            await _studentService.AddAsync(dto);
            return StatusCode(201);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateStudentDto dto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _studentService.UpdateAsync(dto);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _studentService.RemoveAsync(id);
            return Ok();
        }
        catch (ArgumentNullException)
        {
            return NotFound();
        }
    }
}