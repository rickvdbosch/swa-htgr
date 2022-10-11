using Azure.Data.Tables;

using HTGR.Functions.Entities;
using HTGR.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace HTGR.Functions
{
    public static class GetVideos
    {
        [FunctionName(nameof(GetVideos))]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "videos/{partitionKey}")] HttpRequest req,
            [Table("Videos", Connection = "StorageConnectionString")] TableClient tableClient, string partitionKey, ILogger log)
        {
            var videos = tableClient.Query<VideoEntity>().Where(ve => ve.PartitionKey == partitionKey).ToList();

            return new OkObjectResult(videos.Select(v => new VideoModel() 
            {
                Title = v.Title,
                Description = v.Description,
                Url = v.Url
            }));
        }
    }
}
