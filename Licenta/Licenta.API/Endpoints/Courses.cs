namespace Licenta.API.Endpoints
{
    public static class Courses
    {
        public static void RegisterCoursesEndpoints(this IEndpointRouteBuilder routes)
        {
            var users = routes.MapGroup("/api/courses");
            users.MapGet("", () => new List<object>());
        }
    }
}
