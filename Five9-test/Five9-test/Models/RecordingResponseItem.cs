namespace Five9.Models
{
    public class RecordingResponseItem
    {
        public string id {  get; set; }

        public List<Records> records { get; set; }
        public class Records
        {
            public string id { get; set; }
            public string campaignId { get; set; }
            public long created { get; set; }
            public string number { get; set; }
            public string name { get; set; }
            public string callSessionId { get; set; }

        }
    }
}
