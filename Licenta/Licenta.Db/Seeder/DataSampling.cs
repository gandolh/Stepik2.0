using Licenta.Db.DataModel;

namespace Licenta.Db.Seeder
{
    internal class DataSampling
    {

        public static Course[] GetCourses()
        {
            Course[] objects =
        [
            new Course(1, "Introduction to Computer Science"),
            new Course(2, "Data Structures and Algorithms"),
            new Course(3, "Computer Networks"),
            new Course(4, "Database Management Systems"),
            new Course(5, "Software Engineering"),
            new Course(6, "Operating Systems"),
            new Course(7, "Artificial Intelligence"),
            new Course(8, "Cybersecurity"),
            new Course(9, "Web Development"),
            new Course(10, "Machine Learning")
        ];
            return objects;
        }
        public static Teacher[] GetTeacher()
        {
            Teacher[] objects =
             [
                new Teacher(1, "John", "Smith", "password1"),
                 new Teacher(2, "Alice", "Johnson", "password2"),
                 new Teacher(3, "Michael", "Brown", "password3"),
                 new Teacher(4, "Emily", "Davis", "password4"),
                 new Teacher(5, "David", "Martinez", "password5"),
                 new Teacher(6, "Sarah", "Garcia", "password6"),
                 new Teacher(7, "Chris", "Wilson", "password7"),
                 new Teacher(8, "Jennifer", "Lopez", "password8"),
                 new Teacher(9, "Daniel", "Lee", "password9"),
                 new Teacher(10, "Laura", "Taylor", "password10")
             ];
            return objects;
        }
        public static Lesson[] GetLesson()
        {
            Lesson[] objects =
                [
                    new Lesson(1, 1, "Introduction to Computer Science Basics"),
                    new Lesson(2, 2, "Fundamentals of Data Structures"),
                    new Lesson(3, 3, "Networking Principles"),
                    new Lesson(4, 4, "Database Design and Management"),
                    new Lesson(5, 5, "Software Development Methodologies"),
                    new Lesson(6, 6, "Operating System Concepts"),
                    new Lesson(7, 7, "Introduction to Artificial Intelligence"),
                    new Lesson(8, 8, "Cybersecurity Fundamentals"),
                    new Lesson(9, 9, "Web Development Essentials"),
                    new Lesson(10, 10, "Introduction to Machine Learning")
                ];
            return objects;
        }
        public static Exercise[] GetExercise()
        {
            Exercise[] objects =
            [
                new Exercise(1, 1, "Write a program to calculate factorial in C#", 0),
                new Exercise(2, 2, "Implement a linked list data structure", 0),
                new Exercise(3, 3, "Design a simple network topology", 1),
                new Exercise(4, 4, "Create a SQL query to retrieve specific data", 0),
                new Exercise(5, 5, "Develop a basic software using agile methodology", 0),
                new Exercise(6, 6, "Explain the working principles of a file system", 1),
                new Exercise(7, 7, "Implement a basic AI chatbot", 0),
                new Exercise(8, 8, "Identify and fix cybersecurity vulnerabilities", 0),
                new Exercise(9, 9, "Build a simple website using HTML/CSS", 1),
                new Exercise(10, 10, "Develop a linear regression model in Python", 0)
            ];
            return objects;
        }
        public static QuizVariant[] GetQuizVariants()
        {
            QuizVariant[] objects =
            [
                // Exercise 3 - Design a simple network topology
                new QuizVariant(1, 3, "Star Topology", true),
                new QuizVariant(2, 3, "Bus Topology", false),
                new QuizVariant(3, 3, "Ring Topology", false),
                new QuizVariant(4, 3, "Mesh Topology", false),

                // Exercise 6 - Explain the working principles of a file system
                new QuizVariant(5, 6, "File Allocation Table (FAT)", true),
                new QuizVariant(6, 6, "Binary Search Tree", false),
                new QuizVariant(7, 6, "Linked List", false),
                new QuizVariant(8, 6, "Hash Table", false),

                // Exercise 9 - Build a simple website using HTML/CSS
                new QuizVariant(9, 9, "HyperText Markup Language", true),
                new QuizVariant(10, 9, "Cascading Style Sheets", false),
                new QuizVariant(11, 9, "JavaScript", false),
                new QuizVariant(12, 9, "Python", false)
            ];
            return objects;
        }
        public static Student[] GetStudents()
        {
            Student[] objects =
            [
                new Student(1, "Emma", "Johnson", "password1"),
                new Student(2, "Noah", "Williams", "password2"),
                new Student(3, "Olivia", "Brown", "password3"),
                new Student(4, "Liam", "Jones", "password4"),
                new Student(5, "Ava", "Miller", "password5"),
                new Student(6, "Sophia", "Davis", "password6"),
                new Student(7, "Mason", "Garcia", "password7"),
                new Student(8, "Isabella", "Martinez", "password8"),
                new Student(9, "Logan", "Lopez", "password9"),
                new Student(10, "Ethan", "Lee", "password10")
            ];
            return objects;
        }
        public static Submission[] GetSubmissions()
        {
            Submission[] objects =
             [
                new Submission(1, 90, 1, 1),
                 new Submission(2, 75, 2, 2),
                 new Submission(3, 80, 3, 3),
                 new Submission(4, 95, 4, 4),
                 new Submission(5, 85, 5, 5),
                 new Submission(6, 70, 6, 6),
                 new Submission(7, 88, 7, 7),
                 new Submission(8, 92, 8, 8),
                 new Submission(9, 78, 9, 9),
                 new Submission(10, 84, 10, 10)
             ];
            return objects;
        }
        public static Course_Teacher[] GetCourseTeacher()
        {
            Course_Teacher[] objects =
            [
                new Course_Teacher(1, 1),
                new Course_Teacher(1, 2),
                new Course_Teacher(1, 3),
                new Course_Teacher(2, 2),
                new Course_Teacher(2, 3),
                new Course_Teacher(3, 3),
                new Course_Teacher(4, 4),
                new Course_Teacher(5, 5),
                new Course_Teacher(6, 6),
                new Course_Teacher(7, 7),
                new Course_Teacher(8, 8),
                new Course_Teacher(9, 9),
                new Course_Teacher(10, 10)
            ];
            return objects;
        }
        public static Student_Course[] GetStudentCourse()
        {
            Student_Course[] objects =
             [
                new Student_Course(1, 1),
                 new Student_Course(1, 3),
                 new Student_Course(1, 5),

                 new Student_Course(2, 2),
                 new Student_Course(2, 4),
                 new Student_Course(2, 6),

                 new Student_Course(3, 1),
                 new Student_Course(3, 4),
                 new Student_Course(3, 7),

                 new Student_Course(4, 2),
                 new Student_Course(4, 5),
                 new Student_Course(4, 8),

                 new Student_Course(5, 3),
                 new Student_Course(5, 6),
                 new Student_Course(5, 9)
             ];

            return objects;
        }
    }
}
