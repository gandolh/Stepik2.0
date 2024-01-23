
namespace Licenta.UI
{
    public class LicentaConfig
    {

        public LicentaConfig()
        {

        }

        public LicentaConfig(IConfiguration iConfig)
        {
            iConfig.GetSection("LicentaConfig").Bind(this);
        }
        public string UrlApi { get; set; } = string.Empty;
        public KafkaOptions Kafka { get; set; } = new();
        public LicentaEndpoints Endpoints { get; set; } = new();

        internal string GetPathTo(string endpoint)
        {
            return UrlApi + endpoint;
        }
    }

    public class LicentaEndpoints
    {
        public string GetCourses { get; set; } = string.Empty;
        public string GetOneCourse { get; set; } = string.Empty;
        public string GetCodeEvaluations { get; set; } = string.Empty;
        public string GetOneLesson { get; set; } = string.Empty;
        public string GetCoursesByStudent { get; set; } = string.Empty;
        public string Register { get; set; } = string.Empty;
        public string GetUser { get; set; } = string.Empty;
        public string GetExercises { get;  set; } = string.Empty;
        public string GetLessons { get; set; } = string.Empty;
        public string GetModules { get;  set; } = string.Empty;
        public string GetQuizVariants { get;  set; } = string.Empty;
        public string GetStudents { get;  set; } = string.Empty;
        public string GetTeachers { get;  set; } = string.Empty;
        public string GetOneCodeEvaluation { get;  set; } = string.Empty;
        public string GetOneExercise { get;  set; } = string.Empty;
        public string GetOneModule { get;  set; } = string.Empty;
        public string GetOneQuizVariant { get;  set; } = string.Empty;
        public string GetOneStudent { get;  set; } = string.Empty;
        public string GetOneTeacher { get;  set; } = string.Empty;
        public string UpdateCodeEvaluation { get; set; } = string.Empty;
        public string UpdateCourse { get;  set; } = string.Empty;
        public string UpdateExercise { get;  set; } = string.Empty;
        public string UpdateLesson { get;  set; } = string.Empty;
        public string UpdateModule { get;  set; } = string.Empty;
        public string UpdateQuizVariant { get;  set; } = string.Empty;
        public string UpdateStudent { get;  set; } = string.Empty;
        public string UpdateTeacher { get;  set; } = string.Empty;
        public string DeleteCodeEvaluation {get;set;} = string.Empty;
        public string DeleteCourse {get;set;} = string.Empty;
        public string DeleteExercise {get;set;} = string.Empty;
        public string DeleteLesson {get;set;} = string.Empty;
        public string DeleteModule {get;set;} = string.Empty;
        public string DeleteQuizVariant {get;set;} = string.Empty;
        public string DeleteStudent {get;set;} = string.Empty;
        public string DeleteTeacher { get; set; } = string.Empty;

    }
    public class KafkaOptions
    {
        public string Address { get; set; } = string.Empty;
        public KafkaEndpoints Endpoints { get; set; } = new();
        public string GroupId { get; set; } = string.Empty;
        public List<string> SubscribeTopics { get; set; } = new();
    }

    public class KafkaEndpoints
    {
        public string RunCode { get; set; } = string.Empty;
    }
}

