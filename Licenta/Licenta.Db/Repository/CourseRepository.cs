using Npgsql;
using System.Data;

namespace Licenta.Db.Repository
{
    internal class CourseRepository : BaseRepository, IRepository
    {
        public CourseRepository(NpgsqlConnection connection, string tableName) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            ExecSqlCommand(@$"
                CREATE TABLE IF NOT EXISTS {_tableName} (
                    id VARCHAR(40) PRIMARY KEY,
                    name VARCHAR(255) NOT NULL
                )");
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(@"
            INSERT INTO public.course (id, ""name"")
            VALUES
            ('course1', 'Introduction to Programming'),
            ('course2', 'Database Management'),
            ('course3', 'Web Development Basics'),
            ('course4', 'Data Science Fundamentals'),
            ('course5', 'Machine Learning Essentials'),
            ('course6', 'Artificial Intelligence'),
            ('course7', 'Cybersecurity Fundamentals'),
            ('course8', 'Software Engineering Principles'),
            ('course9', 'Project Management'),
            ('course10', 'Network Administration');");
        }


    }
}
