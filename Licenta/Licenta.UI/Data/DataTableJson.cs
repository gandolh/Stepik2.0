
using Licenta.SDK.Models.Dtos;

namespace Licenta.UI.Data
{
    public class DataTableJson
    {
        // column names
        public string[] Headings { get; set; } = [];
        // data -> row by row, column by column
        public string[][] Data { get; set; } = [];

        internal void ImportOverride(List<CodeEvaluationEntryDto> elts)
        {
            int collectionCount = elts.Count();
            Headings = ["Input", "ExpectedResult", ""];
            Data = new string[collectionCount][];
            for (int i = 0; i < collectionCount; i++)
            {
                Data[i] = new string[3];
                Data[i][0] = elts[i].Input;
                Data[i][1] = elts[i].ExpectedResult;
                Data[i][2] = GetBtnGroup(elts[i]);
            }
        }

        private string GetBtnGroup(IDtoWithId dto)
        {
            return dto.Id.ToString();
        }
    }
}
