using System.Runtime.Serialization;

using Azure;
using Azure.Data.Tables;

namespace HTGR.Models
{
    public class VideoEntity : ITableEntity
    {
        #region ITableEntity Members

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        #endregion

        [IgnoreDataMember]
        public string Name
        { 
            get => RowKey;
            set => RowKey = value;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}
