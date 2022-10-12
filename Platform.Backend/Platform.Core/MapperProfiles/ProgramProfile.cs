using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.MapperProfiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<SProgram, ProgramDto>();
        }
    }
}
