﻿using Microsoft.AspNetCore.Mvc;
using Platform.Core.Interfaces;

namespace Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : Controller
    {
        private readonly IProgramsService programService;

        public ProgramsController(IProgramsService programService)
        {
            this.programService = programService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await programService.GetAll());
        }
    }
}