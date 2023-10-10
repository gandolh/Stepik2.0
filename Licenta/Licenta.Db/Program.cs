using Licenta.Db;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");

        LicentaContext context = new LicentaContext();
       await context.InitDb();
    }
}