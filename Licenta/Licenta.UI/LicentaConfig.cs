
using Microsoft.AspNetCore.Http.HttpResults;

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
        public KafkaOptions Kafka { get; set; } = new();
        public LicentaEndpoints Endpoints { get; set; } = new();
    }

    public class LicentaEndpoints
    {
        public static string UrlApi { get; set; } = "https://LICENTA.API:8081";

        public LicentaEndpoints()
        {
            CodeEvaluationEntry = new BaseCrudEndpoint(UrlApi + "/api/CodeEvaluationEntry");
            Course = new BaseCrudEndpoint(UrlApi + "/api/Course");
            Exercise = new BaseCrudEndpoint(UrlApi + "/api/Exercise");
            Lesson = new BaseCrudEndpoint(UrlApi + "/api/Lesson");
            Module = new BaseCrudEndpoint(UrlApi + "/api/Module");
            QuizVariant = new BaseCrudEndpoint(UrlApi + "/api/QuizVariant");
            User = new UserEndpoint(UrlApi + "/api/User");
            Account = new AccountEndpoint(UrlApi + "/api/Account");
        }

        public readonly BaseCrudEndpoint CodeEvaluationEntry;
        public readonly BaseCrudEndpoint Course;
        public readonly BaseCrudEndpoint Exercise;
        public readonly BaseCrudEndpoint Lesson;
        public readonly BaseCrudEndpoint Module;
        public readonly BaseCrudEndpoint QuizVariant;
        public readonly UserEndpoint User;
        public readonly AccountEndpoint Account;
    }

    public class UserEndpoint : BaseCrudEndpoint
    {
        public UserEndpoint(string prefix) : base(prefix)
        {
            GetAllTeachers = prefix + EndpointGetAllTeachers;
            GetAllStudents = prefix + EndpointGetAllStudents;
        }

        private static readonly string EndpointGetAllTeachers = "/GetAllTeachers";
        private static readonly string EndpointGetAllStudents = "/GetAllStudents";
        public readonly string GetAllTeachers;
        public readonly string GetAllStudents;

    }


    public class AccountEndpoint
    {
        public string Prefix;
        public readonly string GetUser;
        public readonly string Register;
        public readonly string JwtLogin;
        public readonly string GenerateToken;
        public readonly string GetProfilePicture;
        public readonly string PostProfilePicture;
        public readonly string Update;


        public AccountEndpoint(string prefix)
        {
            Prefix = prefix;
            GetUser = prefix + "/GetUser";
            Register = prefix + "/Register";
            JwtLogin = prefix + "/JwtLogin";
            GenerateToken = prefix + "/GenerateToken";
            GetProfilePicture = prefix + "/GetProfilePicture";
            PostProfilePicture = prefix + "/PostProfilePicture";
            Update = prefix + "/Update";
        }
    }

    public class BaseCrudEndpoint
    {
        private static readonly string EndpointGetAll = "/GetAll";
        private static readonly string EndpointGetById = "/GetOne";
        private static readonly string EndpointGetFullAll = "/GetFullAll";
        private static readonly string EndpointGetFullById = "/GetFullOne";
        private static readonly string EndpointCreate = "";
        private static readonly string EndpointUpdate = "/Update";
        private static readonly string EndpointDelete = "/Delete";


        public readonly string GetAll;
        public readonly string GetById;
        public readonly string GetFullAll;
        public readonly string GetFullById;
        public readonly string Create;
        public readonly string Update;
        public readonly string Delete;

        public BaseCrudEndpoint(string prefix)
        {
            Prefix = prefix;
            GetAll = prefix + EndpointGetAll;
            GetById = prefix + EndpointGetById;
            GetFullAll = prefix + EndpointGetFullAll;
            GetFullById = prefix + EndpointGetFullById;
            Create = prefix + EndpointCreate;
            Update = prefix + EndpointUpdate;
            Delete = prefix + EndpointDelete;
        }

        public string Prefix;
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

