using Azure;
using Azure.Data.Tables;
using System.Runtime.Serialization;

namespace HTGR.Functions.Entities
{
    public class SessionEntity : ITableEntity
    {
        #region ITableEntity Members

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        #endregion

        [IgnoreDataMember]
        public string Day
        {
            get => PartitionKey;
            set => PartitionKey = value;
        }

        [IgnoreDataMember]
        public string Session
        {
            get => RowKey;
            set => RowKey = value;
        }
        public string Start { get; set; }
        public string End { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Opentoremote { get; set; }
        public string Teamslink { get; set; }
        public string Room { get; set; }
    }
}
