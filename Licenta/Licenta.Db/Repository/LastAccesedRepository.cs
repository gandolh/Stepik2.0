using Npgsql;

namespace Licenta.Db.Repository
{
    public class LastAccesedRepository : BaseRepository, IRepository
    {
        public LastAccesedRepository(NpgsqlConnection connection, string tableName) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            ExecSqlCommand(@$"
                CREATE TABLE IF NOT EXISTS {_tableName} (
                    id VARCHAR(40) PRIMARY KEY,
                    course_id VARCHAR(40) REFERENCES Course(id),
                    user_id VARCHAR(255) NOT NULL,
                    module INT NOT NULL,
                    step INT NOT NULL
                )");

        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(@"INSERT INTO public.lastaccesed (id, course_id, user_id, ""module"", step)
VALUES
    ('access1', 'course1', 'user123', 2, 3),
    ('access2', 'course2', 'user456', 1, 1),
    ('access3', 'course1', 'user789', 4, 2),
    ('access4', 'course3', 'user123', 2, 4),
    ('access5', 'course4', 'user456', 3, 1),
    ('access6', 'course2', 'user789', 2, 2),
    ('access7', 'course5', 'user123', 1, 3),
    ('access8', 'course3', 'user456', 5, 2),
    ('access9', 'course6', 'user789', 1, 4),
    ('access10', 'course4', 'user123', 3, 3);
");
        }
    }
}
