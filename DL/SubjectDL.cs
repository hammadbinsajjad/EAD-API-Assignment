using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;

namespace DL;

public class SubjectDL : ISubjectDL
{
    private StudentDbContext _context;
    
    public SubjectDL(StudentDbContext context)
    {
        _context = context;
    }
    
    public SubjectResponseDto SaveSubject(SubjectRequestDto subjectRequestDto)
    {
        var subject = new SubjectDbDto();
        subject.Name = subjectRequestDto.Name;
        _context.subjectDbDto.Add(subject);
        _context.SaveChanges();
        return new SubjectResponseDto(subject.id, subject.Name);
    }

    public SubjectResponseDto GetSubject(int id)
    {
        var subject = _context.subjectDbDto.FirstOrDefault(s => s.id == id);
        
        if (subject == null)
        {
            return null;
        }
        return new SubjectResponseDto(subject.id, subject.Name);
    }

    public IEnumerable<SubjectResponseDto> GetSubjects()
    {
        var subjects = _context.subjectDbDto.AsEnumerable();
        var subjectResponseDtos = new List<SubjectResponseDto>();
        
        foreach (var subject in subjects)
        {
            subjectResponseDtos.Add(new SubjectResponseDto(subject.id, subject.Name));
        }
        
        return subjectResponseDtos;
    }

    public SubjectResponseDto UpdateSubject(int id, SubjectRequestDto subjectRequestDto)
    {
        var subject = _context.subjectDbDto.FirstOrDefault(s => s.id == id);
        
        if (subject == null)
        {
            return null;
        }
        
        subject.Name = subjectRequestDto.Name;
        _context.SaveChanges();
        return new SubjectResponseDto(subject.id, subject.Name);
    }

    public SubjectResponseDto DeleteSubject(int id)
    {
        var subject = _context.subjectDbDto.FirstOrDefault(s => s.id == id);
        
        if (subject == null)
        {
            return null;
        }
        
        _context.subjectDbDto.Remove(subject);
        _context.SaveChanges();
        return new SubjectResponseDto(subject.id, subject.Name);
    }
}