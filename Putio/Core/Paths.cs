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

namespace Putio.Core
{
    internal static class Paths
    {
        private static readonly string files;
        private static readonly string messages;
        private static readonly string subscriptions;
        private static readonly string transfers;
        private static readonly string urls;
        private static readonly string user;

        static Paths()
        {
            files = "/files";
            messages = "/messages";
            subscriptions = "/subscriptions";
            transfers = "/transfers";
            urls = "/urls";
            user = "/user";
        }

        public static string Files
        {
            get { return files; }
        }

        public static string Messages
        {
            get { return messages; }
        }

        public static string Subscriptions
        {
            get { return subscriptions; }
        }

        public static string Transfers
        {
            get { return transfers; }
        }

        public static string Urls
        {
            get { return urls; }
        }

        public static string User
        {
            get { return user; }
        }
    }
}