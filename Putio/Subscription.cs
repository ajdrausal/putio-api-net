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
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;

    [DebuggerDisplay("{Name}")]
    public class Subscription
    {
        [JsonProperty(PropertyName = "last_update_time")]
        public DateTime? LastUpdateTime { get; set; }

        [JsonProperty(PropertyName = "parent_folder_id")]
        public string ParentFolderId { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "next_update_time")]
        public DateTime? NextUpdateTime { get; set; }

        public string Url { get; set; }

        public bool Paused { get; set; }

        [JsonProperty(PropertyName = "do_filters")]
        public string DoFilters { get; set; }

        [JsonProperty(PropertyName = "dont_filters")]
        public string DontFilters { get; set; }

        public string Id { get; set; }
    }
}