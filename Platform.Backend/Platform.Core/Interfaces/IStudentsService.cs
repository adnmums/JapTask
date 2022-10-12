using Platform.Core.Entities;
using Platform.Core.Requests.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
