namespace Licenta.Sdk.Models.Data
{
    public class AccesedLesson : Lesson
    {
        public int Module { get; set; }
        public int Step { get; set; }

        public AccesedLesson(){}
        public AccesedLesson(int module, int step) : base()
        {
            Module = module;
            Step = step;
        }
        public AccesedLesson(string id, string name,
            int module, int step) : base(id, name)
        {
            Module = module;
            Step = step;
        }
    }
}
