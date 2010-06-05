// <copyright>
//   Copyright (c) 2010 Huseyin Tufekcilerli. All rights reserved.
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <author>Huseyin Tufekcilerli</author>

namespace Putio
{
    using System.Diagnostics;
    using Newtonsoft.Json;
    using Putio.Json;

    [DebuggerDisplay("{Name}")]
    public class User
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "friends_count")]
        public int FriendsCount { get; set; }

        [JsonProperty(PropertyName = "bw_avail_last_month")]
        [JsonConverter(typeof(StringLongConverter))]
        public long BandwidthAvailableLastMonth { get; set; }

        [JsonProperty(PropertyName = "shared_space")]
        public int SharedSpace { get; set; }

        [JsonProperty(PropertyName = "shared_items")]
        public int SharedItems { get; set; }

        [JsonProperty(PropertyName = "bw_quota_available")]
        [JsonConverter(typeof(StringLongConverter))]
        public long BandwidthQuotaAvailable { get; set; }

        [JsonProperty(PropertyName = "disk_quota")]
        [JsonConverter(typeof(StringLongConverter))]
        public long DiskQuota { get; set; }

        [JsonProperty(PropertyName = "disk_quota_available")]
        [JsonConverter(typeof(StringLongConverter))]
        public long DiskQuotaAvailable { get; set; }

        [JsonProperty(PropertyName = "bw_quota")]
        [JsonConverter(typeof(StringLongConverter))]
        public long BandwidthQuota { get; set; }
    }
}