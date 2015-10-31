namespace JSONRssDotNetTelerikForum
{
    using System;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class RSSItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonIgnore]
        [JsonProperty("guid")]
        public List<ID> Guid { get; set; }
        [JsonProperty("pubDate")]
        public DateTime PubDate { get; set; }
    }
}
