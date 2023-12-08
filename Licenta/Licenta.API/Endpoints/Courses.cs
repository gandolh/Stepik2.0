using Licenta.SDK.Models;

namespace Licenta.API.Endpoints
{
    public static class Courses
    {
        public static void RegisterCoursesEndpoints(this IEndpointRouteBuilder routes)
        {
            var users = routes.MapGroup(ApiEndpoints.Courses.Prefix);
            users.MapGet(ApiEndpoints.Courses.GetAll, () => new List<object>());
        }
    }
}
