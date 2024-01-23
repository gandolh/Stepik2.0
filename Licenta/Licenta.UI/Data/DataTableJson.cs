
using Licenta.SDK.Models.Dtos;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Licenta.UI.Data
{
    public class DataTableJson
    {
        // column names
        public string[] Headings { get; set; } = [];
        // data -> row by row, column by column
        public string[][] Data { get; set; } = [];

        internal void ImportOverride(List<FullCodeEvaluationEntryDto> elts)
        {
            Headings = ["Enunciation", "Input", "ExpectedResult", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                Data[i] = new string[headingsCount];
                Data[i][0] = elts[i].Exercise.Enunciation;
                Data[i][1] = elts[i].Input;
                Data[i][2] = elts[i].ExpectedResult;
                Data[i][3] = "crud/codeeval/one/"+ elts[i].Id;
            }
        }

        internal void ImportOverride(List<CourseDto> elts)
        {
            
            Headings = ["Name", "Teachers", "Students", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                string teacherList = elts[i].Teachers.Count() > 2 
                    ? elts[i].Teachers[0].FullName + "," + elts[i].Teachers[1].FullName + "..."
                    : string.Join(",", elts[i].Teachers.Select(el => el.FullName));

                string studentList = elts[i].Students.Count() > 2
                    ? elts[i].Students[0].FullName + "," + elts[i].Students[1].FullName + "..."
                    : string.Join(",", elts[i].Students.Select(el => el.FullName));

                Data[i] = new string[headingsCount];
                Data[i][0] = elts[i].Name;
                Data[i][1] = teacherList;
                Data[i][2] = studentList;
                Data[i][3] = "crud/course/one/" + elts[i].Id;

            }
        }

        internal void ImportOverride(List<ExerciseDto> elts)
        {
            Headings = ["Enunciation", "SampleInput", "IsCodeRunner", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                Data[i] = new string[headingsCount];
                Data[i][0] = elts[i].Enunciation;
                Data[i][1] = elts[i].SampleInput;
                Data[i][2] = elts[i].IsCodeRunner.ToString();
                Data[i][3] = "crud/exercise/one/" + elts[i].Id;
            }
        }

        internal void ImportOverride(List<LessonDto> elts)
        {
            Headings = ["Name", "Body", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                Data[i] = new string[headingsCount];
                Data[i][0] = elts[i].Name;
                Data[i][1] = elts[i].Body;
                Data[i][2] = "crud/lesson/one/" + elts[i].Id;
            }
        }

        internal void ImportOverride(List<ModuleDto> elts)
        {
            Headings = ["Name", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                Data[i] = new string[headingsCount];
                Data[i][0] = elts[i].Name;
                Data[i][1] = "crud/module/one/" + elts[i].Id;
            }
        }

        internal void ImportOverride(List<FullQuizVariantDto> elts)
        {
            Headings = ["Enunciation", "Text", "IsCorrect", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                Data[i] = new string[headingsCount];
                Data[i][0] = elts[i].Exercise.Enunciation;
                Data[i][1] = elts[i].Text;
                Data[i][2] = elts[i].IsCorrect.ToString();
                Data[i][3] = "crud/quizvar/one/" + elts[i].Id;
            }
        }

        internal void ImportOverride(List<TeacherDto> elts)
        {
            Headings = ["Firstname", "Lastname", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                Data[i] = new string[headingsCount];
                Data[i][0] = elts[i].Firstname;
                Data[i][1] = elts[i].Lastname;
                Data[i][2] = "crud/student/one/" + elts[i].Id;
            }
        }

        internal void ImportOverride(List<StudentDto> elts)
        {
            Headings = ["Firstname", "Lastname", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                Data[i] = new string[headingsCount];
                Data[i][0] = elts[i].Firstname;
                Data[i][1] = elts[i].Lastname;
                Data[i][2] = "crud/teacher/one/" + elts[i].Id;
            }
        }
    }
}
