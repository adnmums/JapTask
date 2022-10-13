using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Core.Extensions;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Student;
using Platform.Database;

namespace Platform.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;

        public StudentsService(IMapper mapper, PlatformDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<List<StudentDto>>> Create(CreateStudentDto createStudent)
        {
            var selection = await context.Selections
            .FirstOrDefaultAsync(s => s.Id == createStudent.SelectionId);

            Student student = new Student();
            student.FirstName = createStudent.FirstName;
            student.LastName = createStudent.LastName;
            student.BirthDate = createStudent.BirthDate;
            student.Status = createStudent.Status;
            student.Selection = selection;

            context.Students.Add(student);
            await context.SaveChangesAsync();

            return new ServiceResponse<List<StudentDto>>()
            {
                Data = await context.Students
                .Include(s => s.Selection)
                .ThenInclude(s => s.Program)
                .Select(s => mapper.Map<StudentDto>(s)).ToListAsync() 

            };
        }

        public async Task<ServiceResponse<List<StudentDto>>> Delete(Guid id)
        {
            var student = await context.Students
             .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return new ServiceResponse<List<StudentDto>>()
            {
                Data = await context.Students
                .Include(s => s.Selection)
                .ThenInclude(s => s.Program)
                .Select(s => mapper.Map<StudentDto>(s)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<List<StudentDto>>> GetAll(StudentParameters studentParameters)
        {
            
            return new ServiceResponse<List<StudentDto>>()
            {
                Data = await context.Students
                .Include(s => s.Selection)
                .ThenInclude(s => s.Program)
                .Skip((studentParameters.PageNumber - 1) * studentParameters.PageSize)
                .Take(studentParameters.PageSize)
                .Search(studentParameters.SearchTerm)
                .Select(s => mapper.Map<StudentDto>(s)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<StudentDto>> GetById(Guid id)
        {
            var student = await context.Students
                .Include(s => s.Selection)
                .ThenInclude(s => s.Program)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            return new ServiceResponse<StudentDto>()
            {
                Data = mapper.Map<StudentDto>(student)
            };
        }

        public async Task<ServiceResponse<StudentDto>> Update(Guid id, UpdateStudentDto updatedStudent)
        {
            var selection = await context.Selections
            .FirstOrDefaultAsync(s => s.Id == updatedStudent.SelectionId);

            var student = await context.Students
               .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.BirthDate = updatedStudent.BirthDate;
            student.Status = updatedStudent.Status;
            student.Selection = selection;

            await context.SaveChangesAsync();

            return new ServiceResponse<StudentDto>()
            {
                Data = mapper.Map<StudentDto>(student)
            };
        }
    }
}
