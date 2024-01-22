namespace Licenta.SDK.Models.Dtos
{
    public class TeacherDto : IDtoWithId
    {
        public int Id { get; set; } = 0;
        public string Firstname {get;set;} = string.Empty;
        public string Lastname {get;set;} = string.Empty;
        public string FullName => Firstname + " " + Lastname;
    }
}
