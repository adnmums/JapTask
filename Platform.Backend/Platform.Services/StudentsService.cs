using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Core.Extensions;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Mail;
using Platform.Core.Requests.Student;
using Platform.Database;

namespace Platform.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;
        private readonly IMailService mailService;
        private readonly UserManager<User> userManager;

        public StudentsService(IMapper mapper, PlatformDbContext context, IMailService mailService, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.context = context;
            this.mailService = mailService;
            this.userManager = userManager;
        }

        public async Task<ServiceResponse<List<StudentDto>>> Create(CreateStudentDto createStudent)
        {
            var userExists = await context.Users
                .AnyAsync(user => user.UserName == createStudent.UserName.ToLower().Trim());

            if (userExists)
            {
                throw new BadHttpRequestException("User already exists");
            }

            var selection = await context.Selections
            .FirstOrDefaultAsync(s => s.Id == createStudent.SelectionId);

            //koristiti mapper?
            Student student = new Student();
            student.UserName = createStudent.UserName.ToLower().Trim();
            student.FirstName = createStudent.FirstName;
            student.LastName = createStudent.LastName;
            student.Email = createStudent.Email;
            student.BirthDate = createStudent.BirthDate;
            student.Status = createStudent.Status;
            student.Selection = selection;

            var result = await userManager.CreateAsync(student, createStudent.Password);

            if (!result.Succeeded)
            {
                throw new BadHttpRequestException(result.Errors.First().Description);
            }

            await userManager.AddToRoleAsync(student, "Student");

            var template = EmailTemplate.Template(student.UserName, createStudent.Password);
            
            var email = await mailService.SendEmail(student.Email, EmailTemplate.Subject, template);

            return new ServiceResponse<List<StudentDto>>()
            {
                Data = await context.Students
                .Include(s => s.Selection)
                .ThenInclude(s => s.Program)
                .Include(c => c.Comments)
                .Select(s => mapper.Map<StudentDto>(s)).ToListAsync() 
            };
        }

        public async Task<ServiceResponse<List<StudentDto>>> Delete(int id)
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
                .Include(c => c.Comments)
                .Skip((studentParameters.PageNumber - 1) * studentParameters.PageSize)
                .Take(studentParameters.PageSize)
                .Search(studentParameters.SearchTerm)
                .Select(s => mapper.Map<StudentDto>(s)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<StudentDto>> GetById(int id)
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

        public async Task<ServiceResponse<StudentDto>> Update(int id, UpdateStudentDto updatedStudent)
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
