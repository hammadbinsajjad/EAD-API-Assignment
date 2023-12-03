using Core.Interfaces;
using Core.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers;

[Authorize]
[ApiController]
public class SubjectController : ControllerBase
{
    private ISubjectDL _subjectDl;
    
    public SubjectController(ISubjectDL subjectDl)
    {
        _subjectDl = subjectDl;
    }
    
    [HttpPost("subjects")]
    public IActionResult CreateSubject(SubjectRequestDto requestDto)
    {
        return Ok(_subjectDl.SaveSubject(requestDto));
    }
    
    [HttpGet("subjects")]
    public IActionResult GetSubjects()
    {
        return Ok(_subjectDl.GetSubjects());
    }
    
    [HttpGet("subjects/{id}")]
    public IActionResult GetSubject(int id)
    {
        return Ok(_subjectDl.GetSubject(id));
    }
    
    [HttpPut("subjects/{id}")]
    public IActionResult UpdateSubject(int id, SubjectRequestDto requestDto)
    {
        return Ok(_subjectDl.UpdateSubject(id, requestDto));
    }
    
    [HttpDelete("subjects/{id}")]
    public IActionResult DeleteSubject(int id)
    {
        return Ok(_subjectDl.DeleteSubject(id));
    }
}