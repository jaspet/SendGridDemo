using Newtonsoft.Json;

namespace SendGridDemo.Data
{
    public class SendGridEvent
    {
        public SendGridEvent()
        {

        }
        public string email { get; set; }
        public long timestamp { get; set; }
        [JsonProperty("smtp-id")]
        public string smtpid { get; set; }
        public string @event { get; set; }

        public string category { get; set; }
        public string sg_event_id { get; set; }
        public string sg_message_id { get; set; }
        public string response { get; set; }
        public int attempt { get; set; }
        public string useragent { get; set; }
        public string ip { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string reason { get; set; }
        public string asm_group_id { get; set; }
        public string AuthenticationSignature { get; set; }
    }


}
