using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Core.Extensions;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Selection;
using Platform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Services
{
    public class SelectionsService : ISelectionsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;

        public SelectionsService(IMapper mapper, PlatformDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<ServiceResponse<SelectionDto>> AddStudent(Guid slectionId, Guid studentId)
        {
            var student = await context.Students
               .FirstOrDefaultAsync(s => s.Id == studentId);


            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            var selection = await context.Selections
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == slectionId);


            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            selection.Students.Add(student);
            await context.SaveChangesAsync();


            var selectionResponse = await context.Selections.
                Include(s => s.Program)
               .Include(s => s.Students)
               .FirstOrDefaultAsync(s => s.Id == slectionId);

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selectionResponse)
            };
        }

        public async Task<ServiceResponse<SelectionDto>> Create(CreateSelectionDto newSelection)
        {
            var program = await context.Programs
                .FirstOrDefaultAsync(p => p.Id == newSelection.ProgramId);

            if (program == null)
            {
                throw new KeyNotFoundException("Program not found");
            }

            var student = await context.Students
                .FirstOrDefaultAsync(s => s.Id == newSelection.StudentId);


            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            Selection selection = new Selection
            {
                Title = newSelection.Title,
                StartDate = newSelection.StartDate,
                Status = newSelection.Status,
                Program = program
            };

            student.Selection = selection;
            context.Selections.Add(selection);

            await context.SaveChangesAsync();

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selection)
            };
        }

        public async Task<ServiceResponse<List<SelectionDto>>> Delete(Guid id)
        {
            var selection = await context.Selections
               .FirstOrDefaultAsync(s => s.Id == id);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            context.Selections.Remove(selection);

            await context.SaveChangesAsync();

            return new ServiceResponse<List<SelectionDto>>()
            {
                Data = await context.Selections
                .Include(s => s.Program)
                .Include(s => s.Students)
                .Select(s => mapper.Map<SelectionDto>(s))
                .ToListAsync()
            };
        }

        public async Task<ServiceResponse<List<SelectionDto>>> GetAll(SelectionParameters selectionParameters)
        {
            return new ServiceResponse<List<SelectionDto>>()
            {
                Data = await context.Selections
                 .Include(s => s.Program)
                 .Include(s => s.Students)
                 .Skip((selectionParameters.PageNumber - 1) * selectionParameters.PageSize)
                 .Take(selectionParameters.PageSize)
                 .Search(selectionParameters.SearchTerm)
                 .Select(s => mapper.Map<SelectionDto>(s))
                 .ToListAsync()
            };
        }

        public async Task<ServiceResponse<SelectionDto>> GetById(Guid id)
        {
            var selection = await context.Selections.
             Include(s => s.Program)
            .Include(s => s.Students)
            .FirstOrDefaultAsync(s => s.Id == id);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selection)
            };
        }

        public async Task<ServiceResponse<SelectionDto>> RemoveStudent(Guid slectionId, Guid studentId)
        {
            var student = await context.Students
              .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            Selection? selection = await context.Selections
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == slectionId);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            selection.Students.Remove(student);
            await context.SaveChangesAsync();

            var selectionResponse = await context.Selections.
                Include(s => s.Program)
               .Include(s => s.Students)
               .FirstOrDefaultAsync(s => s.Id == slectionId);

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selectionResponse)
            };
        }

        public async Task<ServiceResponse<SelectionDto>> Update(Guid id, UpdateSelectionDto updatedSelection)
        {
            var selection = await context.Selections
               .FirstOrDefaultAsync(s => s.Id == id);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            selection.Title = updatedSelection.Title;
            selection.Status = updatedSelection.Status;
            selection.StartDate = updatedSelection.StartDate;
            selection.EndDate = updatedSelection.EndDate;

            await context.SaveChangesAsync();

            var selectionResponse = await context.Selections.
                Include(s => s.Program)
               .Include(s => s.Students)
               .FirstOrDefaultAsync(s => s.Id == id);

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selectionResponse)
            };
        }
    }
}
