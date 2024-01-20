namespace Licenta.API.Models
{
    public class CreateResult
    {

        // It should look like: "{Type} created with id: [id]"
        public string ComposedResult { get; set; }
        public int Id { get; set; }
        public string Error { get; set; } = string.Empty;

        public CreateResult(Type t, int id)
        {
            ComposedResult = $"{t.Name} created with Id: {id}";
        }
    }
}
