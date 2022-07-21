namespace HTGR.Web.Models
{
    public class SpeakerObject
    {
        public Collection collection { get; set; }
    }

    public class Collection
    {
        public Item[] items { get; set; }
    }

    public class Item
    {
        public Speaker[] data { get; set; }
    }

    public class Speaker
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
