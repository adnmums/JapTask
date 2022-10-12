using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.MapperProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, SingleStudentDto>();
            CreateMap<CreateStudentDto, Student>();
        }
    }
}
