using Microsoft.AspNetCore.Mvc;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Student;
using Platform.Services;

namespace Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto newStudent)
        {
            return Ok(await studentsService.Create(newStudent));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await studentsService.Delete(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] StudentParameters studentParameters)
        {
            return Ok(await studentsService.GetAll(studentParameters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await studentsService.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateStudentDto updatedStudent)
        {
            return Ok(await studentsService.Update(id, updatedStudent));
        }
    }
}
