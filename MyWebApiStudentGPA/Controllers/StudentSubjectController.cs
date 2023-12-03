using DL.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers;

[ApiController]
public class StudentSubjectController : ControllerBase
{
    private StudentDbContext _context;
    
    public StudentSubjectController(StudentDbContext context)
    {
        _context = context;
    }
    
    [HttpPost("student-subjects")]
    public IActionResult CreateStudentSubject(StudentSubjectDbDto studentSubjectDbDto)
    {
        _context.studentSubjectDbDto.Add(studentSubjectDbDto);
        _context.SaveChanges();

        return Ok(studentSubjectDbDto);
    }
    
    [HttpGet("student-subjects")]
    public IActionResult GetStudentSubjects()
    {
        var studentSubjects = _context.studentSubjectDbDto.ToList();
        return Ok(studentSubjects);
    }
    
    [HttpPut("student-subjects/{id}")]
    public IActionResult UpdateStudentSubject(int id, StudentSubjectDbDto studentSubjectDbDto)
    {
        var studentSubject = _context.studentSubjectDbDto.FirstOrDefault(s => s.Id == id);
        if (studentSubject == null)
        {
            return NotFound();
        }

        studentSubject.SID = studentSubjectDbDto.SID;
        studentSubject.SubjectId = studentSubjectDbDto.SubjectId;
        studentSubject.GPA = studentSubjectDbDto.GPA;
        _context.studentSubjectDbDto.Update(studentSubject);
        _context.SaveChanges();
        return Ok(studentSubject);
    }
    
    [HttpDelete("student-subjects/{id}")]
    public IActionResult DeleteStudentSubject(int id)
    {
        var studentSubject = _context.studentSubjectDbDto.FirstOrDefault(s => s.Id == id);
        if (studentSubject == null)
        {
            return NotFound();
        }

        _context.studentSubjectDbDto.Remove(studentSubject);
        _context.SaveChanges();
        return Ok(studentSubject);
    }
}