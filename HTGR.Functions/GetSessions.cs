using System.Net;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

using HTGR.Functions.Entities;
using HTGR.Models;

namespace HTGR.Functions
{
    public class GetSessions
    {
        public GetSessions()
        {
        }

        [Function("GetSessions")]
        public SessionModel[] Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "sessions")] HttpRequestData req,
            [TableInput("Sessions", Connection = "StorageConnectionString")] IEnumerable<SessionEntity> sessionInput, ILogger log)
        {
            var sessions = sessionInput.OrderBy(se => se.PartitionKey).ThenBy(se => se.Start).ToList();

            var response = req.CreateResponse(HttpStatusCode.OK);
            return sessions.Select(v => new SessionModel()
            {
                Duration = v.Duration,
                Day = v.Day,
                Description = v.Description,
                End = v.End,
                Opentoremote = v.Opentoremote,
                Room = v.Room,
                Session = v.Session,
                Speaker = v.Speaker,
                Start = v.Start,
                Teamslink = v.Teamslink
            }).ToArray();
        }
    }
}