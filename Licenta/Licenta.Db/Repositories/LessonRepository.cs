﻿using Licenta.Db.Data;
using Licenta.Db.DataModel;
using Licenta.Db.Seeder.Interfaces;

namespace Licenta.Db.Repositories
{
    public class LessonRepository : BaseRepository<Lesson>
    {
        public LessonRepository(IDapperDbClient dbClient) : base(dbClient)
        {
        }

        public override async Task CreateTableAsync()
        {
            string sql = $"""
                CREATE TABLE {_tableName}(
                    Id SERIAL PRIMARY KEY,
                    ModuleId INT REFERENCES Module(Id),
                    Name VARCHAR(255),
                    Body VARCHAR(10000)
                );
                
                """;
            await _dbClient.ExecuteAsync(sql);
        }

        public override async Task InsertAsync(Lesson data)
        {
            string sql = $"""
                INSERT INTO {_tableName}
                (ModuleId, Name, Body) 
                VALUES (@ModuleId, @Name, @Body);
            """;
            var rowsAffected = await _dbClient.ExecuteAsync(sql, data);
        }

        public async Task<Lesson?> GetJoinedLesson(int lessonId)
        {
            string getLessonSql = $"SELECT * FROM Lesson WHERE Id={lessonId}";
            Lesson lesson = await _dbClient.QueryFirstOrDefaultAsync<Lesson>(getLessonSql);
            if(lesson == null)
                return null;

            string getExercisesSql = $"SELECT * FROM Exercise WHERE LessonId={lessonId}";
            List<Exercise> exercises = await _dbClient.QueryAsync<Exercise>(getExercisesSql);

            IEnumerable<int> idsQuizExercises = exercises.Where(e => e.Type == ExerciseType.Quiz).Select(e => e.Id);
            if(idsQuizExercises.Count() > 0)
            {
                string joinedIdQuizes = string.Join(',', idsQuizExercises);
                string getQuizezSql = $"SELECT * FROM QuizVariant WHERE exerciseId in ({joinedIdQuizes})";
                List<QuizVariant> quizVariants = await _dbClient.QueryAsync<QuizVariant>(getQuizezSql);
                exercises.ForEach(e => e.QuizVariants = quizVariants.Where(qv => qv.ExerciseId == e.Id).ToList());
            }
            lesson.Exercises = exercises;
            return lesson;
        }
    }
}
