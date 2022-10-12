using Platform.Core.Entities;
using Platform.Core.Requests.Program;

namespace Platform.Core.Interfaces
{
    public interface IProgramsService
    {
        Task<ServiceResponse<List<ProgramDto>>> GetAll();
    }
}
