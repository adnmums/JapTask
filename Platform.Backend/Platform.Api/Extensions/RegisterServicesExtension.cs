﻿using Platform.Core.Interfaces;
using Platform.Services;

namespace Platform.Api.Extensions
{
    public static class RegisterServicesExtension
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IStudentsService, StudentsService>();
            service.AddScoped<IProgramsService, ProgramsService>();
            service.AddScoped<ISelectionsService, SelectionsService>();
            service.AddScoped<ICommentsService, CommentsService>();
        }
    }
}
