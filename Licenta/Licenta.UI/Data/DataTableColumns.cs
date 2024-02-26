namespace Licenta.UI.Data
{
    public class DataTableColumns : List<DatatableColumn?>
    {
    }

    public class DatatableColumn
    {
        public int Select { get; set; }
        public string CellClass { get; set; } = string.Empty;
        public int MaxCharacters { get; set; } = -1;
    }
}
