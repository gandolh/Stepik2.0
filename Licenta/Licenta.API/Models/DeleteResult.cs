namespace Licenta.API.Models
{
    public class DeleteResult
    {

        public string ComposedResult { get; set; }
        public int Id { get; set; }
        public string Error { get; set; } = string.Empty;

        public DeleteResult(Type t, int id)
        {
            ComposedResult = $"{t.Name} deleted with Id: {id}";
        }
    }
}
