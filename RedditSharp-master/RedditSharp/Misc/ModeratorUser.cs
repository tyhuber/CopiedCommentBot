﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditSharp.Master;

namespace RedditSharp.Misc
{
    public class ModeratorUser
    {
        public ModeratorUser(Reddit reddit, JToken json)
        {
            JsonConvert.PopulateObject(json.ToString(), this, reddit.JsonSerializerSettings);
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mod_permissions")]
        [JsonConverter(typeof (ModeratorPermissionConverter))]
        public ModeratorPermission Permissions { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
