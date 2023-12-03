using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;

namespace Core.Interfaces
{
    public interface ISubjectDL
    {
        public SubjectResponseDto SaveSubject(SubjectRequestDto subjectRequestDto);
        public SubjectResponseDto GetSubject(int id);
        public IEnumerable<SubjectResponseDto> GetSubjects();
        public SubjectResponseDto UpdateSubject(int id, SubjectRequestDto subjectRequestDto);
        public SubjectResponseDto DeleteSubject(int id);
    }
}
