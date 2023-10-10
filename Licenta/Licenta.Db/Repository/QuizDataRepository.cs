using Npgsql;

namespace Licenta.Db.Repository
{
    public class QuizDataRepository : BaseRepository, IRepository
    {
        public QuizDataRepository(NpgsqlConnection connection, string tableName) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            ExecSqlCommand(@$"
            CREATE TABLE IF NOT EXISTS {_tableName} (
                id VARCHAR(40) PRIMARY KEY,
                lesson_id VARCHAR(40) REFERENCES Lesson(id),
                question TEXT,
                answer TEXT
            );");
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(@"INSERT INTO public.quizdata (id, lesson_id, question, answer)
VALUES
    ('quiz1', 'lesson1', 'What is a variable?', 'A variable is a named storage location in a program.'),
    ('quiz2', 'lesson2', 'What is an SQL SELECT statement?', 'The SQL SELECT statement retrieves data from a database.'),
    ('quiz3', 'lesson3', 'How do you define a string in Python?', 'You can define a string in Python using single or double quotes.'),
    ('quiz4', 'lesson4', 'What does HTML stand for?', 'HTML stands for Hypertext Markup Language.'),
    ('quiz5', 'lesson5', 'What is Pandas in Python used for?', 'Pandas is used for data manipulation and analysis.'),
    ('quiz6', 'lesson6', 'Why is database normalization important?', 'Normalization reduces data redundancy and improves data integrity.'),
    ('quiz7', 'lesson7', 'What is overfitting in machine learning?', 'Overfitting occurs when a model learns noise in the training data.'),
    ('quiz8', 'lesson8', 'What is the purpose of the ""document"" object in JavaScript?', 'The ""document"" object represents the HTML document and its contents.'),
    ('quiz9', 'lesson9', 'What is a neural network layer?', 'A neural network layer is a collection of interconnected neurons.'),
    ('quiz10', 'lesson10', 'Why is data visualization important?', 'Data visualization helps to understand and communicate data patterns.');
");
        }
    }
}
