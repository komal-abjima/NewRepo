namespace Five9_test.Models
{
    public class CampaignProfileInfo
    {
        public string ANI { get; set; }
        public string description { get; set; }
        public campaignDialingSchedule dialingSchedule {  get; set; }
        public int dialingTimeout { get; set; }
        public int initialCallPriority { get; set; }
        public string name { get; set; }

        public int numberOfAttempts { get; set; }

    }

    public class campaignDialingSchedule
    {
        public string dialASAPSortOrder { get; set; } //lifo
        public int dialASAPTimeout { get; set; }
        public string dialASAPTimeoutPeriod { get; set; } //minute
        public string dialingOrder { get; set; }  //PrimaryAlt1Alt2 string Primary > first alternate > second alternate
        public campaignNumberSchedule dialingSchedules { get; set; }
        public string  includeNumbers {get; set;} //Primary


    }

    public class campaignNumberSchedule
    {
        public string number { get; set; } //Primary

    }

}
