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

    [DebuggerDisplay("{Name}")]
    public class Item
    {
        public string Name { get; set; }

        [JsonProperty(PropertyName = "download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty(PropertyName = "parent_id")]
        public string ParentId { get; set; }

        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }

        [JsonProperty(PropertyName = "file_icon_url")]
        public string FileIconUrl { get; set; }

        [JsonProperty(PropertyName = "stream_url")]
        public string StreamUrl { get; set; }

        [JsonProperty(PropertyName = "screenshot_url")]
        public string ScreenshotUrl { get; set; }

        [JsonProperty(PropertyName = "is_dir")]
        public bool IsDirectory { get; set; }

        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbnailUrl { get; set; }

        public string Type { get; set; }

        public string Id { get; set; }

        public long Size { get; set; }
    }
}