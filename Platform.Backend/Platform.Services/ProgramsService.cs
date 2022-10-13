using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Program;
using Platform.Database;

namespace Platform.Services
{
    public class ProgramsService : IProgramsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;

        public ProgramsService(IMapper mapper, PlatformDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<ServiceResponse<List<ProgramDto>>> GetAll()
        {
            
            return new ServiceResponse<List<ProgramDto>>()
            {
                Data = await context.Programs.Select(s => mapper.Map<ProgramDto>(s)).ToListAsync()
            };
        }
    }
}
