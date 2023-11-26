namespace Licenta.Db.Seeder.Interfaces
{
    public interface IDatabaseConnectionSettings
    {
        string Host { get; set; }
        uint Port { get; set; }
        string DatabaseName { get; set; }
        string User { get; set; }
        string Password { get; set; }
        bool Pooling { get; set; }
    }
}
