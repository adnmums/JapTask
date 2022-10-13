using Platform.Core.MapperProfiles;

namespace Platform.Api.Extensions
{
    public static class RegisterAutomapperProfilesExtension
    {
        public static void RegisterAutomapperProfiles(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ProgramProfile));
            service.AddAutoMapper(typeof(StudentProfile));
            service.AddAutoMapper(typeof(CommentProfile));
            service.AddAutoMapper(typeof(SelectionProfile));
        }
    }
}
