using Licenta.Db.DataModel;
using Licenta.SDK.Models;

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
        public static Role[] GetRole()
        {
            Role[] roles =
               {
                    new Role(1, RoleType.Admin, 1),
                    new Role(2, RoleType.Student, 2),
                    new Role(3, RoleType.Student, 3),
                    new Role(6, RoleType.Student, 6),
                    new Role(8, RoleType.Student, 8),
                    new Role(10, RoleType.Student, 10),
                    new Role(4, RoleType.Teacher, 4),
                    new Role(5, RoleType.Teacher, 5),
                    new Role(7, RoleType.Teacher, 7),
                    new Role(9, RoleType.Teacher, 9)
                };

            return roles;
        }
        public static Lesson[] GetLessons()
        {
            Lesson[] lessons =
            [
        new Lesson(1, 1, "Introduction to Computer Science Basics",
        "Introduction to Computer Science Basics is a foundational course designed" +
        " to provide learners with a comprehensive understanding of fundamental concepts " +
        "in computer science. This course serves as a gateway for individuals with varying " +
        "levels of technical background to explore the key principles that underpin the world" +
        " of computing. Topics covered include algorithms, data structures, programming languages," +
        " and problem-solving techniques. Participants will gain hands-on experience through " +
        "practical exercises, fostering critical thinking and computational skills. Whether you're" +
        " a beginner eager to demystify the world of computers or someone looking to solidify " +
        "foundational knowledge, this course lays the groundwork for a deeper exploration into the" +
        " diverse and dynamic field of computer science."),
                new Lesson(2, 1, "Programming Fundamentals", ""),
                new Lesson(3, 2, "Data Structures Overview", ""),
                new Lesson(4, 2, "Advanced Data Structures", ""),
                new Lesson(5, 3, "Networking Principles", ""),
                new Lesson(6, 3, "Network Security", ""),
                new Lesson(7, 4, "Database Design and Management", ""),
                new Lesson(8, 4, "Query Optimization", ""),
                new Lesson(9, 5, "Software Development Methodologies", ""),
                new Lesson(10, 5, "Agile Best Practices", ""),
                // Add more lessons as needed
            ];

            return lessons;
        }

        public static Exercise[] GetExercise()
        {
            Exercise[] objects =
            [
                new Exercise(1, 1, "Write a program to calculate factorial", "5", 0),
                new Exercise(2, 2, "Implement a linked list data structure", "5", 0),
                new Exercise(3, 3, "Design a simple network topology", "", 1),
                new Exercise(4, 4, "Create a SQL query to retrieve specific data", "5", 0),
                new Exercise(5, 5, "Develop a basic software using agile methodology", "5", 0),
                new Exercise(6, 6, "Explain the working principles of a file system", "", 1),
                new Exercise(7, 7, "Implement a basic AI chatbot", "", 0),
                new Exercise(8, 8, "Identify and fix cybersecurity vulnerabilities", "5", 0),
                new Exercise(9, 9, "Build a simple website using HTML/CSS", "", 1),
                new Exercise(10, 10, "Develop a linear regression model in Python", "5", 0)
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

        public static CodeEvaluationEntry[] GetCodeEvaluationEntry()
        {
            CodeEvaluationEntry[] objects =
           [
               new CodeEvaluationEntry(1, 1, "1", "1"),
               new CodeEvaluationEntry(2, 1, "2", "2"),
               new CodeEvaluationEntry(3, 1, "3", "6"),
               new CodeEvaluationEntry(4, 1, "4", "24"),
               new CodeEvaluationEntry(5, 1, "5", "120"),

           ];
            return objects;
        }

        public static PortalUser[] GetUsers()
        {
            PortalUser[] objects =
            [
                new PortalUser(1, "Emma", "Johnson", "password1"),
                new PortalUser(2, "Noah", "Williams", "password2"),
                new PortalUser(3, "Olivia", "Brown", "password3"),
                new PortalUser(4, "Liam", "Jones", "password4"),
                new PortalUser(5, "Ava", "Miller", "password5"),
                new PortalUser(6, "Sophia", "Davis", "password6"),
                new PortalUser(7, "Mason", "Garcia", "password7"),
                new PortalUser(8, "Isabella", "Martinez", "password8"),
                new PortalUser(9, "Logan", "Lopez", "password9"),
                new PortalUser(10, "Ethan", "Lee", "password10")
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
                 new Submission(4, 95, 3, 4),
                 new Submission(5, 85, 6, 5),
                 new Submission(6, 70, 6, 6),
                 new Submission(7, 88, 8, 7),
                 new Submission(8, 92, 8, 8),
                 new Submission(9, 78, 10, 9),
                 new Submission(10, 84, 10, 10)
             ];
            return objects;
        }

        public static Course_User[] GetCourseUser()
        {

            // 4, 5, 7, 9 are teachers
            // 0 - as student , 1 - as teacher
            Course_User[] modules =
 [
                new Course_User { Id = 1, CourseId = 1, UserId= 1, ParticipationType = 0  },
                new Course_User { Id = 2, CourseId = 1, UserId= 4, ParticipationType = 1 },
                new Course_User { Id = 3, CourseId = 2, UserId= 2, ParticipationType = 0 },
                new Course_User { Id = 4, CourseId = 2, UserId= 5, ParticipationType = 1  },
                new Course_User { Id = 5, CourseId = 3, UserId= 7, ParticipationType = 1  },
                new Course_User { Id = 6, CourseId = 3, UserId= 3, ParticipationType = 0 },
                new Course_User { Id = 7, CourseId = 4, UserId= 7, ParticipationType = 1  },
                new Course_User { Id = 8, CourseId = 4, UserId= 6, ParticipationType = 0  },
                new Course_User { Id = 9, CourseId = 5, UserId= 9, ParticipationType = 1  },
                new Course_User { Id = 10, CourseId = 5, UserId= 8, ParticipationType = 0 },
            ];

            return modules;
        }

        public static Module[] GetModules()
        {
            Module[] modules =
            [
                new Module { Id = 1, CourseId = 1, Name = "Module 1 - Introduction" },
                new Module { Id = 2, CourseId = 1, Name = "Module 2 - Basics" },
                new Module { Id = 3, CourseId = 2, Name = "Module 1 - Fundamentals" },
                new Module { Id = 4, CourseId = 2, Name = "Module 2 - Advanced Concepts" },
                new Module { Id = 5, CourseId = 3, Name = "Module 1 - Networking Basics" },
                new Module { Id = 6, CourseId = 3, Name = "Module 2 - Routing and Switching" },
                new Module { Id = 7, CourseId = 4, Name = "Module 1 - Database Design" },
                new Module { Id = 8, CourseId = 4, Name = "Module 2 - Query Optimization" },
                new Module { Id = 9, CourseId = 5, Name = "Module 1 - Agile Methodologies" },
                new Module { Id = 10, CourseId = 5, Name = "Module 2 - Project Management" },
            ];

            return modules;
        }
    }
}
