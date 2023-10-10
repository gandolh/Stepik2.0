using Npgsql;

namespace Licenta.Db.Repository
{
    public class EventRepository : BaseRepository, IRepository
    {
        public EventRepository(NpgsqlConnection connection, string tableName) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            ExecSqlCommand(@$"
                CREATE TABLE IF NOT EXISTS {_tableName} (
                    id VARCHAR(40) PRIMARY KEY,
                    title VARCHAR(255) NOT NULL,
                    due_time TIMESTAMPTZ NOT NULL,
                    description TEXT
                )");
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(@"INSERT INTO public.""event"" (id, title, due_time, description)
VALUES
    ('event1', 'Assignment Due', '2023-10-15 12:00:00', 'Submit your assignment by the due date.'),
    ('event2', 'Quiz Deadline', '2023-10-20 23:59:59', 'Complete the quiz by the deadline.'),
    ('event3', 'Guest Speaker Session', '2023-10-25 15:00:00', 'Join the guest speaker session.'),
    ('event4', 'Workshop Day', '2023-11-05 09:30:00', 'Participate in the hands-on workshop.'),
    ('event5', 'Final Exam', '2023-11-30 10:00:00', 'Prepare for the final exam.'),
    ('event6', 'Networking Event', '2023-12-10 18:00:00', 'Attend the networking event.'),
    ('event7', 'Project Presentation', '2023-12-20 14:00:00', 'Present your project to the class.'),
    ('event8', 'Career Fair', '2024-01-15 10:00:00', 'Explore job opportunities at the career fair.'),
    ('event9', 'Graduation Ceremony', '2024-05-25 15:30:00', 'Celebrate your graduation.'),
    ('event10', 'Seminar on AI', '2024-06-10 17:00:00', 'Learn about the latest developments in AI.');
");
        }
    }
}
