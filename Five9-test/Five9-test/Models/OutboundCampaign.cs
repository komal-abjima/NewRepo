namespace Five9_test.Models
{
    public class OutboundCampaign
    {
        public string CampaignName { get; set; }
        public string? ActionOnAnswerMachine { get; set; }
        public bool? DialNumberOnTimeout { get; set; }
        public string? DialingMode { get; set; }
        public int? DialingPriority { get; set; }
        public GeneralCampaignModel? GeneralCampaign { get; set; }
        public CampaignModel? Campaign { get; set; }
    }

    public class GeneralCampaignModel
    {
        public int? AnalyzeLevel { get; set; }
        public string ListDialingMode { get; set; }
    }

    public class CampaignModel
    {
        public bool AutoRecord { get; set; }
        public string CallWrapup { get; set; }
        public string FtpHost { get; set; }
        public string FtpPassword { get; set; }
        public string FtpUser { get; set; }
        public bool UseFtp { get; set; }
    }
}
