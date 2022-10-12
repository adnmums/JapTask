using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Comment;
using Platform.Core.Requests.Program;
using Platform.Core.Requests.Selection;
using Platform.Core.Requests.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, SingleStudentDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<SProgram, ProgramDto>();
            CreateMap<Selection, SelectionDto>();
            CreateMap<Selection, SingleSelectionDto>();
            CreateMap<CreateSelectionDto, Selection>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
