namespace JSONRssDotNetTelerikForum
{
    using Newtonsoft.Json;

    public class ID
    {
        [JsonProperty("isPermaLink")]
        public bool IsPermaLink { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}