using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StudentDL : IStudentDL
    {
        StudentDbContext _stContext;

        public StudentDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public StudentDetailSubjectResponseDto GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<StudentDbDto> GetStudents()
        {
            return _stContext.studentDbDto.AsEnumerable();
        }

        public IEnumerable<StudentResponseDto> GetStudentsAsync()
        {
            var students = GetStudents();
            var studentResponseDtos = new List<StudentResponseDto>();
            foreach (var student in students)
            {
                studentResponseDtos.Add(new StudentResponseDto(student.Id, student.getName(), student.getRollNumber(), student.getPhoneNumber()));
            }
            return studentResponseDtos;
        }

        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto)
        {
            Console.WriteLine(studentRequestDto.Name);
            var st = new StudentDbDto();
            st.Name = studentRequestDto.Name;
            st.PhoneNumber = studentRequestDto.PhoneNumber;
            st.RollNumber = studentRequestDto.RollNo;
            _stContext.studentDbDto.Add(st);
            _stContext.SaveChanges();
            
            return new StudentResponseDto(st.Id, st.getName(), st.getRollNumber(), st.getPhoneNumber());
        }
    }
}
