﻿namespace Five9.Models
{
    public class Five9LoginApiResponseItem
    {
        public string userId { get; set; }
        public string tokenId { get; set; }
        public string sessionId { get; set; }
        public string orgId { get; set; }
        public string agentId { get; set; }
        public string supervisorID { get; set; }



        public Context context { get; set; }

        public class Context
        {
            public string farmId { get; set; }
        }
    
    }
}
