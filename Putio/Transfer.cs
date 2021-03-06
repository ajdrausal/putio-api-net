﻿// <copyright>
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

    /*
    {
      "response": {
        "total": 1,
        "results": [
          {
            "status": "Downloading",
            "percent_done": "1",
            "id": "358874",
            "name": "Shutter.Island.2010.720p.BluRay.x264.DTS-WiKi"
          }
        ]
      },
      "error": false,
      "user_name": "huseyin",
      "id": 6190
    }
    */

    [DebuggerDisplay("{Name}")]
    public class Transfer
    {
        public string Status { get; set; }

        [JsonProperty(PropertyName = "percent_done")]
        [JsonConverter(typeof(StringIntegerConverter))]
        public int PercentDone { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}