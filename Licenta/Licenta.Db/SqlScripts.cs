using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Db
{
    public static class SqlScripts
    {
        #region seed
        public static readonly string CoursesSeed = @"
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
            ('course10', 'Network Administration');";
        public static readonly string EventsSeed = @"INSERT INTO public.""event"" (id, title, due_time, description)
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
";
        public static readonly string LastAccesedSeed = @"INSERT INTO public.lastaccesed (id, course_id, user_id, ""module"", step)
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
";
        public static readonly string LessonSeed = @"INSERT INTO public.lesson (id, course_id, ""name"", lesson_type, theory, problem_question)
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
";
        public static readonly string QuizDataSeed = @"INSERT INTO public.quizdata (id, lesson_id, question, answer)
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
";
        #endregion
        #region create tables
        public static readonly string CoursesCreate = @"
                CREATE TABLE IF NOT EXISTS {0} (
                    id VARCHAR(40) PRIMARY KEY,
                    name VARCHAR(255) NOT NULL
                )";
        public static readonly string EventsCreate = @"
                CREATE TABLE IF NOT EXISTS {0} (
                    id VARCHAR(40) PRIMARY KEY,
                    title VARCHAR(255) NOT NULL,
                    due_time TIMESTAMPTZ NOT NULL,
                    description TEXT
                )";
        public static readonly string LastAccesedCreate = @"
                CREATE TABLE IF NOT EXISTS {0} (
                    id VARCHAR(40) PRIMARY KEY,
                    course_id VARCHAR(40) REFERENCES Course(id),
                    user_id VARCHAR(255) NOT NULL,
                    module INT NOT NULL,
                    step INT NOT NULL
                )";
        public static readonly string LessonCreate = @"
            CREATE TABLE IF NOT EXISTS {0} (
                id VARCHAR(40) PRIMARY KEY,
                course_id VARCHAR(40) REFERENCES Course(id),
                name VARCHAR(255) NOT NULL,
                lesson_type INT NOT NULL,
                theory TEXT,
                problem_question TEXT
            );";
        public static readonly string QuizDataCreate = @"CREATE TABLE IF NOT EXISTS {0} (
                id VARCHAR(40) PRIMARY KEY,
                lesson_id VARCHAR(40) REFERENCES Lesson(id),
                question TEXT,
                answer TEXT
);";
        #endregion
    }
}
