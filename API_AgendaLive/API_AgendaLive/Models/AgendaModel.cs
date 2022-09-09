namespace API_AgendaLive.Models
{
    public class AgendaModel
    {
        public int id { get; set; }

        public string liveName { get; set; }

        public string channelName { get; set; }

        public DateTime liveDate { get; set; }

        public string liveLink { get; set; }

        public DateTime registrationDate { get; set; }

    }
}
