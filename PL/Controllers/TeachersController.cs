using BLL.DTOs.SubjectDtos;
using BLL.DTOs.TeacherDtos;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PL.ViewModels;
using System.Collections.Generic;

namespace PL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService)
	{
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var teachers = await _teacherService.GetAllAsync();
        var json = JsonConvert.SerializeObject(teachers, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

        return Ok(json);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var teacher = await _teacherService.GetByIdAsync(id);
        var json = JsonConvert.SerializeObject(teacher, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

        return Ok(json);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] QueryFilter query)
    {
        var teachers = await _teacherService.Filter(query.searchText,
                                                    query.operatorCode,
                                                    query.startDate, query.endDate,
                                                    query.startAge, query.endAge);
        return Ok(teachers);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] AddTeacherDto dto,
                                          [FromBody] List<SubjectDto> subjects) 
    {
        if (ModelState.IsValid)
        {
            dto.TeacherSubjects = subjects;
            await _teacherService.AddAsync(dto);
            return StatusCode(201);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateTeacherDto dto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _teacherService.UpdateAsync(dto);
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
            await _teacherService.RemoveAsync(id);
            return Ok();
        }
        catch (ArgumentNullException)
        {
            return NotFound();
        }
    }
}