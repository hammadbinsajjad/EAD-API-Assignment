using Core.Interfaces;
using Core.Models.RequestModels;
using DL;
using DL.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyWebApiStudentGPA.Controllers;

[ApiController]
[Authorize]
public class StudentController : ControllerBase
{
    StudentDbContext _context;
    IStudentDL _studentDl;
    
    public StudentController(StudentDbContext context, IStudentDL studentDl)
    {
        _context = context;
        _studentDl = studentDl;
    }
    
    [HttpPost("students")]
    public IActionResult CreateStudent(StudentRequestDto requestDto)
    {
        return Ok(_studentDl.SaveStudent(requestDto));
    }
    
    [HttpGet("students")]
    public IActionResult GetStudents()
    {
        return Ok(_studentDl.GetStudentsAsync());
    }
    
    [HttpGet("students/{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = _context.studentDbDto.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound("Student not found");
        }
        return Ok(student);
    }
    
    
    [HttpPut("students/{id}")]
    public IActionResult UpdateStudent(int id, StudentRequestDto requestDto)
    {
        var student = _context.studentDbDto.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound("Student not found");
        }
        student.Name = requestDto.Name;
        student.PhoneNumber = requestDto.PhoneNumber;
        student.RollNumber = requestDto.RollNo;
        _context.SaveChanges();
        return Ok(student);
    }
    
    [HttpDelete("students/{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = _context.studentDbDto.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound("Student not found");
        }
        _context.studentDbDto.Remove(student);
        _context.SaveChanges();
        return Ok(student);
    }
    
    [HttpGet("students/{id}/subjects")]
    public IActionResult GetStudentSubjects(int id)
    {
        var student = _context.studentDbDto.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound("Student not found");
        }
        var studentSubjects = _context.studentSubjectDbDto.Where(s => s.SID == id).ToList();
        return Ok(studentSubjects);
    }
}