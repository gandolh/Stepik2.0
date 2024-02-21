namespace Licenta.Db.DataModel
{
    internal class Course_User
    {
        public int Id { get; set; } 
        public int CourseId { get; set; }
        public int UserId { get; set; }
        // 0 - as student , 1 - as teacher
        public int ParticipationType { get; set; }  

    }
}
