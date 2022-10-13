using Platform.Core.Entities;
using Platform.Core.Requests.Student;

namespace Platform.Core.Interfaces
{
    public interface IStudentsService
    {
        Task<ServiceResponse<List<StudentDto>>> GetAll(StudentParameters studentParameters);
        Task<ServiceResponse<StudentDto>> GetById(Guid id);
        Task<ServiceResponse<List<StudentDto>>> Create(CreateStudentDto createStudent);
        Task<ServiceResponse<StudentDto>> Update(Guid id, UpdateStudentDto updatedStudent);
        Task<ServiceResponse<List<StudentDto>>> Delete(Guid id);
    }
}
