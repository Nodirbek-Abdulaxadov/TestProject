using BLL.DTOs.SubjectDtos;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectsController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectsController(ISubjectService subjectService)
	{
        _subjectService = subjectService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var subjects = await _subjectService.GetAllAsync();
        return Ok(subjects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var subject = await _subjectService.GetByIdAsync(id);
        return Ok(subject);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddSubjectDto dto)
    {
        if (ModelState.IsValid)
        {
            await _subjectService.AddAsync(dto);
            return Ok();
        }
        
        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateSubjectDto dto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _subjectService.UpdateAsync(dto);
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
        if (id > 0)
        {
            try
            {
                await _subjectService.RemoveAsync(id);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        return BadRequest();
    }
}