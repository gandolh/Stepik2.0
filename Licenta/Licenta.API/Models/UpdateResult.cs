namespace Licenta.API.Models
{
    public class UpdateResult
    {

        public string ComposedResult { get; set; }
        public int Id { get; set; }
        public string Error { get; set; } = string.Empty;

        public UpdateResult(Type t, int id)
        {
            ComposedResult = $"{t.Name} updated with Id: {id}";
        }
    }
}
