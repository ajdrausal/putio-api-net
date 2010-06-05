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
    using System.Collections.Generic;

    public class PutioException : Exception
    {
        private readonly string methodUrl;

        private readonly IDictionary<string, object> parameters;

        public PutioException(string message, string methodUrl, IDictionary<string, object> parameters)
            : base(message)
        {
            this.methodUrl = methodUrl;
            this.parameters = parameters;
        }

        public string MethodUrl
        {
            get { return this.methodUrl; }
        }

        public IDictionary<string, object> Parameters
        {
            get { return this.parameters; }
        }
    }
}