using Licenta.Db.Data;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class UserRepository 
    {
        protected readonly IDapperDbClient _dbClient;

        public UserRepository(IDapperDbClient dbClient)
        {
            _dbClient = dbClient;
        }

        public async Task GetAll()
        {
            throw new NotImplementedException();
            //string sqlGetAllStudents = "SELECT * FROM Student";
            //string sqlGetAllTeachers = "SELECT * FROM Teacher";
            //string sqlGetAll= sqlGetAllTeachers + "\n" + sqlGetAllStudents;
            //Dapper.SqlMapper.GridReader reader = await _dbClient.QueryMultipleAsync(sqlGetAll);
            //User[] users = reader.Read<User>().ToArray();
        }

        public async Task<User?> GetOne(string email)
        {
            string sqlGetAllStudents = $"SELECT * FROM Student where Email='{email}'";
            string sqlGetAllTeachers = $"SELECT * FROM Teacher where Email='{email}'";
            User? user = null;

            user = await _dbClient.QueryFirstOrDefaultAsync<User>(sqlGetAllStudents);
            if (user == null) user = await _dbClient.QueryFirstOrDefaultAsync<User>(sqlGetAllTeachers);

            return user;
        }
    }
}
