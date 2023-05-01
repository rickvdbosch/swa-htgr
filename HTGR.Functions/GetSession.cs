using HTGR.Functions.Entities;
using HTGR.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HTGR.Functions
{
    public class GetSession
    {
        private readonly ILogger _logger;

        public GetSession(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetSession>();
        }

        [Function("GetSession")]
        public SessionModel Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "sessions/{day}/{title}")] HttpRequestData req,
            [TableInput("Sessions", "{day}", "{title}", Connection = "StorageConnectionString")] SessionEntity session, string day, string title, ILogger log)
        {
            return new SessionModel()
            {
                Duration = session.Duration,
                Day = session.Day,
                Description = session.Description,
                End = session.End,
                Opentoremote = session.Opentoremote,
                Room = session.Room,
                Session = session.Session,
                Speaker = session.Speaker,
                Start = session.Start,
                Teamslink = session.Teamslink
            };
        }
    }
}
