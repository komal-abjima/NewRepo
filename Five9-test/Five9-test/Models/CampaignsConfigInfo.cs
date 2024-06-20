namespace Five9_test.Models
{
    public class CampaignsConfigInfo
    {
        public string[] campaignIds {  get; set; }
        public string defaultCampaignId { get; set; }
        public bool selectAllowed {  get; set; }
        public bool selectNoneAllowed { get; set; }
    }
}
