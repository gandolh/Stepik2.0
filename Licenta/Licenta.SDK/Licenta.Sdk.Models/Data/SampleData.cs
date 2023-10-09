namespace Licenta.Sdk.Models.Data
{
    public static class SampleData
    {
        public static AccesedLesson[] GetAccesedLessons()
        {
            return new AccesedLesson[]
            {

            new AccesedLesson("353a88db-42aa-46f4-a805-ad110ee13519", "Python", 1, 4),
            new AccesedLesson("68ddd960-2def-4bf5-bfde-9798473dc525", "Red Black Tree", 3, 2),
            new AccesedLesson("85f5cd1a-8a8b-437f-989a-bb9fba754f15", "Testare functionala", 5, 2),
            new AccesedLesson("81ea6673-84d3-4290-b36b-5b75eb922d0e", "GDPIO", 2, 7),
            new AccesedLesson("8b902ce4-85f5-48fb-8712-3f441bde5034", "Singletone", 1, 6),
            new AccesedLesson("919a8eca-6822-4a4c-9626-448eeffa46a7", "Trimitere de Email", 7, 2),
            new AccesedLesson("1f4ca0e7-f062-4f2b-83b1-c729755901bc", "Algoritmi nesupravegheati", 3, 1),
            new AccesedLesson("f3545b10-4de7-49e0-bc3f-0dce27d103f4", "PHP", 2, 7),
            };
        }

        public static Course[] GetCourses()
        {
            var lessons = GetAccesedLessons();
            return new Course[]
            {
               new Course("7da3c4a1-ac1b-4a81-967c-0598f184656f", "Programare 1", lessons[0]),
               new Course("5fa271bb-9252-4fc9-8fe9-ca32669d2863", "Structuri de Date Avansate", lessons[1]),
               new Course("4e0544c7-9d0b-41e4-8b49-d900c384ebad", "Testarea sistemelor software", lessons[2]),
               new Course("a23428ca-1f69-47e7-8a46-a224f442f220", "Programarea sistemelor in timp real", lessons[3]),
               new Course("da994f4b-ddc3-4332-8689-0b1a898b43a1", "Sabloane de proiectare", lessons[4]),
               new Course("baea68f8-a080-409d-b1af-ae0ebff2afb6", "Robotic Process Automation", lessons[5]),
               new Course("97c3d895-aac8-4d30-8481-bf6ab08ee39b", "Inteligenta Artificiala", lessons[6]),
               new Course("115f1cc5-1e24-48dc-8c33-97092f649ca7", "Tehnologii Web", lessons[7])
            };
        }

    }
}
