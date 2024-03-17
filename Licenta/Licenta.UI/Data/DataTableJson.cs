
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
            elts.Sort((e1, e2) => e1.Id - e2.Id);
            Headings = ["Id", "Enunciation", "Input", "ExpectedResult", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                int index = -1;
                Data[i] = new string[headingsCount];
                Data[i][++index] = elts[i].Id.ToString();
                Data[i][++index] = elts[i].Exercise.Enunciation;
                Data[i][++index] = elts[i].Input;
                Data[i][++index] = elts[i].ExpectedResult;
                // last item should be id of element
                Data[i][++index] = elts[i].Id.ToString();
            }
        }

        internal void ImportOverride(List<FullCourseDto> elts)
        {
            elts.Sort((e1, e2) => e1.Id - e2.Id);
            Headings = ["Id", "Name", "Teachers", "Students", ""];
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

                int index = -1;
                Data[i] = new string[headingsCount];
                Data[i][++index] = elts[i].Id.ToString();
                Data[i][++index] = elts[i].Name;
                Data[i][++index] = teacherList;
                Data[i][++index] = studentList;

                // last item should be id of element
                Data[i][++index] = elts[i].Id.ToString();

            }
        }

        internal void ImportOverride(List<ExerciseDto> elts)
        {
            elts.Sort((e1, e2) => e1.Id - e2.Id);
            Headings = ["Id", "Enunciation", "SampleInput", "IsCodeRunner", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                int index = -1;
                Data[i] = new string[headingsCount];
                Data[i][++index] = elts[i].Id.ToString();
                Data[i][++index] = elts[i].Enunciation;
                Data[i][++index] = elts[i].SampleInput;
                Data[i][++index] = elts[i].IsCodeRunner.ToString();
                // last item should be id of element
                Data[i][++index] = elts[i].Id.ToString();
            }
        }

        internal void ImportOverride(List<FullLessonDto> elts)
        {
            elts.Sort((e1, e2) => e1.Id - e2.Id);
            Headings = ["Id", "Name", "Body", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                int index = -1;
                Data[i] = new string[headingsCount];
                Data[i][++index] = elts[i].Id.ToString();
                Data[i][++index] = elts[i].Name;
                Data[i][++index] = elts[i].Body;
                // last item should be id of element
                Data[i][++index] = elts[i].Id.ToString();
            }
        }

        internal void ImportOverride(List<ModuleDto> elts)
        {
            elts.Sort((e1, e2) => e1.Id - e2.Id);
            Headings = ["Id", "Name", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                int index = -1;
                Data[i] = new string[headingsCount];
                Data[i][++index] = elts[i].Id.ToString();
                Data[i][++index] = elts[i].Name;
                // last item should be id of element
                Data[i][++index] = elts[i].Id.ToString();
            }
        }

        internal void ImportOverride(List<FullQuizVariantDto> elts)
        {
            elts.Sort((e1, e2) => e1.Id - e2.Id);
            Headings = ["Id", "Text", "IsCorrect", "Enunciation", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                int index = -1;
                Data[i] = new string[headingsCount];
                Data[i][++index] = elts[i].Id.ToString();
                Data[i][++index] = elts[i].Text;
                Data[i][++index] = elts[i].IsCorrect.ToString();
                Data[i][++index] = elts[i].Exercise.Enunciation;
                // last item should be id of element
                Data[i][++index] = elts[i].Id.ToString();
            }
        }

        internal void ImportOverride(List<PortalUserDto> elts)
        {
            elts.Sort((e1, e2) => e1.Id - e2.Id);
            Headings = ["Id", "Firstname", "Lastname", ""];
            int collectionCount = elts.Count();
            int headingsCount = Headings.Count();
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                int index = -1;
                Data[i] = new string[headingsCount];
                Data[i][++index] = elts[i].Id.ToString();
                Data[i][++index] = elts[i].Firstname;
                Data[i][++index] = elts[i].Lastname;
                // last item should be id of element
                Data[i][++index] = elts[i].Id.ToString();
            }
        }

       
    }
}
