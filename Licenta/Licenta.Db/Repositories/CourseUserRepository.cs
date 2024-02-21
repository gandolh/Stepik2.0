using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    internal class CourseUserRepository : BaseRepository<Course_User>
    {
        public CourseUserRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }


        public override async Task CreateTableAsync()
        {
            string sql = @"
            CREATE TABLE IF NOT EXISTS Course_User (
                Id SERIAL PRIMARY KEY,
                CourseId INT REFERENCES Course(Id),
                UserId INT REFERENCES PortalUser(Id),
                ParticipationType INT
            );
        ";
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Course_User data)
        {
            string sql = @"
            INSERT INTO Course_User (CourseId, UserId, ParticipationType) 
            VALUES (@CourseId, @UserId, @ParticipationType);
        ";
            await _dbClient.ExecuteAsync(sql, data);
        }

        public override async Task UpdateAsync(Course_User data)
        {
            string sql = @"
            UPDATE Course_User SET 
            CourseId = @CourseId,
            UserId = @UserId,
            ParticipationType = @ParticipationType
            WHERE Id = @Id;
        ";
            await _dbClient.ExecuteAsync(sql, data);
        }
    }
}
