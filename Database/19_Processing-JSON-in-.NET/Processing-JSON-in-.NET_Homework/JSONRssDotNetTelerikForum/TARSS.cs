namespace JSONRssDotNetTelerikForum
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TARSS
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("item")]
        public ICollection<RSSItem> Item { get; set; }
    }
}
