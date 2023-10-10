using Npgsql;

namespace Licenta.Db.Repository
{
    public class LessonRepository : BaseRepository, IRepository
    {
        public LessonRepository(NpgsqlConnection connection, string tableName) : base(connection, tableName) { }

        public void CreateTableIfNotExists()
        {
            ExecSqlCommand(@$"
            CREATE TABLE IF NOT EXISTS {_tableName} (
                id VARCHAR(40) PRIMARY KEY,
                course_id VARCHAR(40) REFERENCES Course(id),
                name VARCHAR(255) NOT NULL,
                lesson_type INT NOT NULL,
                theory TEXT,
                problem_question TEXT
            );");
        }

        public void SeedIfEmpty()
        {
            ExecSqlCommand(@"INSERT INTO public.lesson (id, course_id, ""name"", lesson_type, theory, problem_question)
VALUES
    ('lesson1', 'course1', 'Introduction to Programming', 1, 'This lesson covers the basics of programming.', 'Write a ""Hello, World!"" program.'),
    ('lesson2', 'course2', 'Database Fundamentals', 1, 'Learn about relational databases and SQL.', 'Write a simple SQL query.'),
    ('lesson3', 'course1', 'Data Types in Python', 1, 'Explore data types in Python programming.', 'Convert an integer to a string.'),
    ('lesson4', 'course3', 'HTML and CSS Basics', 1, 'Get started with web development using HTML and CSS.', 'Create a simple webpage.'),
    ('lesson5', 'course4', 'Data Analysis with Python', 1, 'Analyze data using Python and Pandas.', 'Calculate basic statistics.'),
    ('lesson6', 'course2', 'Normalization in Databases', 1, 'Understand the concept of database normalization.', 'Normalize a sample table.'),
    ('lesson7', 'course5', 'Machine Learning Algorithms', 1, 'Explore various machine learning algorithms.', 'Implement a decision tree algorithm.'),
    ('lesson8', 'course3', 'JavaScript Basics', 1, 'Learn the fundamentals of JavaScript.', 'Create an interactive web feature.'),
    ('lesson9', 'course6', 'Neural Networks', 1, 'Study artificial neural networks and deep learning.', 'Build a simple neural network.'),
    ('lesson10', 'course4', 'Data Visualization', 1, 'Visualize data using Python libraries.', 'Create a data visualization.');
");
        }
    }
}
