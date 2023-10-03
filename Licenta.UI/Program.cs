namespace Licenta.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder
            .ConfigureServices()
            .UseBasePath("/licenta")
            .ConfigureBlazor()
            .Run();
        }
    }
}