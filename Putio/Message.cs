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

    [DebuggerDisplay("{FileName}")]
    public class Message
    {
        /*
        "user_file_id": "6036582",
        "hidden": "0",
        "user_id": "6190",
        "description": null,
        "title": "<a rel=\"userfile\" href=\"/file/6036582\">dnrtv_0004.zip.torrent</a> <span class=\"dash-gray\">(4.87K) downloaded</span>",
        "importance": "0",
        "file_name": "dnrtv_0004.zip.torrent",
        "file_type": "1",
        "from_user_id": null,
        "id": "5324666",
        "channel": "2"
         */

        [JsonProperty(PropertyName = "user_file_id")]
        public string UserFileId { get; set; }

        public string Hidden { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string Importance { get; set; }

        [JsonProperty(PropertyName = "file_name")]
        public string FileName { get; set; }

        [JsonProperty(PropertyName = "file_type")]
        public string FileType { get; set; }

        [JsonProperty(PropertyName = "from_user_id")]
        public string FromUserId { get; set; }

        public string Id { get; set; }

        public string Channel { get; set; }
    }
}